FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TimeBilling.Api/TimeBilling.Api.csproj", "TimeBilling.Api/"]
COPY ["TimeBilling.Domain.Abstract/TimeBilling.Domain.Abstract.csproj", "TimeBilling.Domain.Abstract/"]
COPY ["TimeBilling.Contracts/TimeBilling.Contracts.csproj", "TimeBilling.Contracts/"]
COPY ["TimeBilling.Model/TimeBilling.Model.csproj", "TimeBilling.Model/"]
COPY ["TimeBilling.Domain/TimeBilling.Domain.csproj", "TimeBilling.Domain/"]
COPY ["TimeBilling.Persistance/TimeBilling.Persistance.csproj", "TimeBilling.Persistance/"]
RUN dotnet restore "./TimeBilling.Api/./TimeBilling.Api.csproj"
COPY . .
WORKDIR "/src/TimeBilling.Api"
RUN dotnet build "./TimeBilling.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG Version
ARG Description
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TimeBilling.Api.csproj" -p:Version="$Version" -p:Description="$Description" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeBilling.Api.dll"]