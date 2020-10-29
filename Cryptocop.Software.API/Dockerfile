FROM mcr.microsoft.com/dotnet/core/sdk:3.1

LABEL maintainer="Ríkharður Friðgeirsson"

ENV ASPNETCORE_URLS=http://+:5000

COPY . /app

WORKDIR /app/Cryptocop.Software.API

RUN dotnet restore

ENTRYPOINT [ "dotnet", "run" ]
