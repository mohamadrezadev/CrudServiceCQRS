#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/LocalDatabase.db", "Src/LocalDatabase.db"]
COPY ["Src/Endpoints/Endpoint.web/EndPoint.Web/EndPoint.Web.csproj", "Src/Endpoints/Endpoint.web/EndPoint.Web/"]
COPY ["Src/Application/Application.csproj", "Src/Application/"]
COPY ["Src/Domain/Domain.csproj", "Src/Domain/"]
COPY ["Src/Infrastructure/Infrastructure.csproj", "Src/Infrastructure/"]
COPY ["Src/Persistances/Persistances.csproj", "Src/Persistances/"]
RUN dotnet restore "./Src/Endpoints/Endpoint.web/EndPoint.Web/EndPoint.Web.csproj"
COPY . .
WORKDIR "/src/Src/Endpoints/Endpoint.web/EndPoint.Web"
RUN dotnet build "./EndPoint.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EndPoint.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EndPoint.Web.dll"]