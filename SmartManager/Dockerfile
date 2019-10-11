FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .

COPY SmartManager.Shared/*.csproj ./SmartManager.Shared/
RUN dotnet restore ./SmartManager.Shared

COPY SmartManager.Domain/*.csproj ./SmartManager.Domain/
RUN dotnet restore ./SmartManager.Domain

COPY SmartManager.Infra/*.csproj ./SmartManager.Infra/
RUN dotnet restore ./SmartManager.Infra

COPY SmartManager.API/*.csproj ./SmartManager.API/
RUN dotnet restore ./SmartManager.API

# copy everything else and build app
COPY . ./
WORKDIR /app/SmartManager.API
RUN dotnet publish -c Release -o out

RUN ls /app/SmartManager.API/out/

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/SmartManager.API/out ./
ENTRYPOINT ["dotnet", "SmartManager.API.dll"]