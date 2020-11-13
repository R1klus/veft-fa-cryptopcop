FROM python:3

LABEL maintainer="Ríkharður Friðgeirsson"

ENV PYTHON_ENV production

copy . /app
WORKDIR /app

RUN pip install requests pika

ENTRYPOINT [ "python", "-u", "app.py" ]