#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TimeBilling.Model/TimeBilling.Model.csproj", "TimeBilling.Model/"]
COPY ["TimeBilling.Common.Contracts/TimeBilling.Common.Contracts.csproj", "TimeBilling.Common.Contracts/"]
COPY ["TimeBilling.Common.Messaging/TimeBilling.Common.Messaging.csproj", "TimeBilling.Common.Messaging/"]
COPY ["TimeBilling.Api/TimeBilling.Api.csproj", "TimeBilling.Api/"]
COPY ["TimeBilling.Api.Domain.Abstract/TimeBilling.Api.Domain.Abstract.csproj", "TimeBilling.Api.Domain.Abstract/"]
COPY ["TimeBilling.Api.Domain/TimeBilling.Api.Domain.csproj", "TimeBilling.Api.Domain/"]
COPY ["TimeBilling.Api.Persistance/TimeBilling.Api.Persistance.csproj", "TimeBilling.Api.Persistance/"]
RUN dotnet restore "./TimeBilling.Api/./TimeBilling.Api.csproj"
COPY . .
WORKDIR "/src/TimeBilling.Api"
RUN dotnet build "./TimeBilling.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TimeBilling.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeBilling.Api.dll"]