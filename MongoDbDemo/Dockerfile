#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MongoDbDemo.csproj", "MongoDbDemo/"]
RUN dotnet restore "MongoDbDemo/MongoDbDemo.csproj"
COPY . .
WORKDIR "/src/MongoDbDemo"
RUN dotnet build "MongoDbDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MongoDbDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoDbDemo.dll"]