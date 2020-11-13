FROM python:3

LABEL maintainer="Ríkharður Friðgeirsson"

ENV PYTHON_ENV production

copy . /app
WORKDIR /app

RUN pip install requests pika
RUN pip install Card-Validator


ENTRYPOINT [ "python", "-u", "app.py" ]