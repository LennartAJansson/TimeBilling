#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TimeBilling.Api.Domain.Abstract/TimeBilling.Api.Domain.Abstract.csproj", "TimeBilling.Api.Domain.Abstract/"]
COPY ["TimeBilling.Model/TimeBilling.Model.csproj", "TimeBilling.Model/"]
COPY ["TimeBilling.Common.Messaging/TimeBilling.Common.Messaging.csproj", "TimeBilling.Common.Messaging/"]
COPY ["TimeBilling.Common.Contracts/TimeBilling.Common.Contracts.csproj", "TimeBilling.Common.Contracts/"]
COPY ["TimeBilling.Projector/TimeBilling.Projector.csproj", "TimeBilling.Projector/"]
COPY ["TimeBilling.Projector.Domain.Abstract/TimeBilling.Projector.Domain.Abstract.csproj", "TimeBilling.Projector.Domain.Abstract/"]
COPY ["TimeBilling.Projector.Domain/TimeBilling.Projector.Domain.csproj", "TimeBilling.Projector.Domain/"]
COPY ["TimeBilling.Projector.Persistance/TimeBilling.Projector.Persistance.csproj", "TimeBilling.Projector.Persistance/"]
RUN dotnet restore "./TimeBilling.Projector/./TimeBilling.Projector.csproj"
COPY . .
WORKDIR "/src/TimeBilling.Projector"
RUN dotnet build "./TimeBilling.Projector.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TimeBilling.Projector.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeBilling.Projector.dll"]