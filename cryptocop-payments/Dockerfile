FROM python:3

LABEL maintainer="Ríkharður Friðgeirsson"

copy . /app
WORKDIR /app

RUN pip install requests pika
RUN pip install Card-Validator


ENTRYPOINT [ "python", "app.py" ]