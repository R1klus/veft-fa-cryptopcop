FROM mcr.microsoft.com/dotnet/core/sdk:latest

LABEL maintainer="Ríkharður Friðgeirsson"

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
COPY . /app

WORKDIR /app/Cryptocop.Software.API

RUN dotnet restore

ENTRYPOINT [ "dotnet", "run"]