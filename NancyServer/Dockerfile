# Build .exe
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

COPY . /nancy

WORKDIR /nancy
RUN dotnet build 

# all we need is the dll
CMD ["dotnet", "run" ]