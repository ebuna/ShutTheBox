# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-arm64v8 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim-arm64v8
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ShutTheBox.dll"]