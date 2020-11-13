import pika
import json
from time import sleep
from os import environ
from cardvalidator import luhn

EXCHANGE_NAME = "crypto-exchange"
CREATE_ORDER_QUEUE = "payment_queue"
CREATE_ORDER_ROUTING_KEY = "create-order"


def get_connection_string() -> dict:
    with open(f'./config/mb.{environ.get("PYTHON_ENV")}.json', 'r') as f:
        return json.load(f)


def connect_to_mesage_broker():
    error = False
    while not error:
        try:
            connection = get_connection_string()
            credentials = pika.PlainCredentials(connection['user'], connection['password'])
            connection = pika.BlockingConnection(
                pika.ConnectionParameters(connection['host'], 5672, connection['virtualhost'], credentials))
            channel = connection.channel()
            return channel
        except:
            sleep(5)
            continue


def setup_channel(exchange_name, queue_name, routing_key, channel):
    # Declare the exchange, if it doesn't exist
    channel.exchange_declare(exchange_name, exchange_type='direct', durable=True)
    # Declare the queue, if it doesn't exist
    channel.queue_declare(queue=queue_name, durable=True)
    # Bind the queue to a specific exchange with a routing key
    channel.queue_bind(exchange=exchange_name, queue=queue_name, routing_key=routing_key)


def validate_creditcard_number(card_number: str):
    if luhn.is_valid(card_number):
        message = f"Credit Card Number: {card_number} is Valid."
    else:
        message = f"Credit Card Number: {card_number} is Invalid."

    print(message)
    with open("log.txt", "a") as f:
        f.write(message)


def order_create_event(ch, method, properties, data):
    parsed_data = json.loads(data)
    card_number = parsed_data["CreditCard"]
    validate_creditcard_number(card_number)


def start_listening():
    new_channel = connect_to_mesage_broker()
    setup_channel(EXCHANGE_NAME, CREATE_ORDER_QUEUE, CREATE_ORDER_ROUTING_KEY, new_channel)

    new_channel.basic_consume(CREATE_ORDER_QUEUE, order_create_event, auto_ack=True)
    print("Listening to \n"
          "Message Broker on {}\n"
          "Exchange: {}\n"
          "Queue: {}\n"
          "Routing Key: {}\n".format(get_connection_string()["host"], EXCHANGE_NAME, CREATE_ORDER_QUEUE, CREATE_ORDER_ROUTING_KEY))
    new_channel.start_consuming()


if __name__ == '__main__':
    start_listening()

