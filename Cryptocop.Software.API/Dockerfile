FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

LABEL maintainer="Ríkharður Friðgeirsson"

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Cryptocop.Software.API/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Cryptocop.Software.API.dll"]