#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookingSystem.API/BookingSystem.API.csproj", "BookingSystem.API/"]
COPY ["BookingSystem.Application/BookingSystem.Application.csproj", "BookingSystem.Application/"]
COPY ["BookingSystem.Domain/BookingSystem.Domain.csproj", "BookingSystem.Domain/"]
COPY ["BookingSystem.Infrastructure/BookingSystem.Infrastructure.csproj", "BookingSystem.Infrastructure/"]
RUN dotnet restore "./BookingSystem.API/./BookingSystem.API.csproj"
COPY . .
WORKDIR "/src/BookingSystem.API"
RUN dotnet build "./BookingSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookingSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingSystem.API.dll"]