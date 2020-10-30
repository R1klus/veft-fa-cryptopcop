import pika
import requests
import json
from time import sleep
from os import environ

EXCHANGE_NAME = "crypto-exchange"
CREATE_ORDER_QUEUE = "email-queue"
CREATE_ORDER_ROUTING_KEY = "create-order"


def get_connection_string() -> dict:
    with open('./config/mb.production.json', 'r') as f:
        return json.load(f)


def connect_to_mesage_broker():
    error = False
    while not error:
        try:
            connection = get_connection_string()
            user = connection["user"]
            password = connection["password"]
            host = connection["host"]
            virtual_host = connection["virtualhost"]
            print(f"Host: {host}")
            print(f"User: {user}")
            print(f"Password: {password}")
            print(f"VirtualHost: {virtual_host}")

            credentials = pika.PlainCredentials(user, password)
            connection = pika.BlockingConnection(
                pika.ConnectionParameters(host, 5672, virtual_host, credentials))
            channel = connection.channel()
            return channel
        except:
            print("Connection failed retry in 5 seconds")
            sleep(5)
            continue


def setup_channel(exchange_name, queue_name, routing_key, channel):
    # Declare the exchange, if it doesn't exist
    channel.exchange_declare(exchange_name, exchange_type='direct', durable=True)
    # Declare the queue, if it doesn't exist
    channel.queue_declare(queue=queue_name, durable=True)
    # Bind the queue to a specific exchange with a routing key
    channel.queue_bind(exchange=exchange_name, queue=queue_name, routing_key=routing_key)


def write_payload(payload):
    print("Email Queue: " + str(payload))


def send_simple_message(to, subject, body):
    return requests.post(
        "https://api.mailgun.net/v3/sandbox549155f073d54c3da1e0919a30b85a58.mailgun.org/messages",
        auth=("api", "43d93cc4c2757e534f36a0811a3a400c-9b1bf5d3-abc6c8d8"),
        data={"from": "Mailgun Sandbox <postmaster@sandbox549155f073d54c3da1e0919a30b85a58.mailgun.org>",
              "to": to,
              "subject": subject,
              "html": body})


def order_create_event(ch, method, properties, data):
    parsed_data = json.loads(data)
    email = parsed_data["Email"]

    name = parsed_data["FullName"]
    address = parsed_data["StreetName"] + parsed_data["HouseNumber"]
    city = parsed_data["City"]
    zip_code = parsed_data["ZipCode"]
    country = parsed_data["Country"]
    date = parsed_data["OrderDate"]
    total_price = parsed_data["TotalPrice"]

    items = parsed_data["OrderItems"]
    products = ""
    for item in items:
        identifier = item["ProductIdentifier"]
        quantity = item["Quantity"]
        unit_price = item["UnitPrice"]
        item_total_price = item["TotalPrice"]
        products += f"<tr><td>{identifier.capitalize()}</td><td>{quantity}</td><td>{unit_price:.2f}</td><td>{item_total_price:.2f}</td></tr>"

    order_template = f'<h2>Thank you for ordering @ Cryptocop!</h2><p>We hope this Final Assignment is good enough for a passing grade!</p><h4>Name: {name}</h4><h4>Address: {address}</h4><h4>City: {city}</h4><h4>Zip Code: {zip_code}</h4><h4>Country: {country}</h4><h4>Date of order: {date}</h4><h4>Total Price: {total_price:.2f}</h4><table><thead><tr style="background-color: rgba(155, 155, 155, .2)"><th>Product Name</th><th>Quantity</th><th>Unit price</th><th>Total Price</th></tr></thead><tbody>{products}</tbody></table>'

    representation = order_template.format(name, address, city, zip_code, country, date, total_price)
    send_simple_message(email, "Your order has been placed", representation)
    with open("log.txt", "a") as f:
        f.write(f"Email Log: Name: {name} Date: {date} Email: {email}\n")
    print(f"Confirmation Email sent to: {email}")


def start_listening():
    new_channel = connect_to_mesage_broker()
    setup_channel(EXCHANGE_NAME, CREATE_ORDER_QUEUE, CREATE_ORDER_ROUTING_KEY, new_channel)

    new_channel.basic_consume(CREATE_ORDER_QUEUE, order_create_event, auto_ack=True)
    print("Listening to \n"
          "Message Broker on {}\n"
          "Exchange: {}\n"
          "Queue: {}\n"
          "Routing Key: {}\n".format(get_connection_string()["host"], EXCHANGE_NAME, CREATE_ORDER_QUEUE,
                                     CREATE_ORDER_ROUTING_KEY))
    new_channel.start_consuming()


print("Email Service Started")
start_listening()
