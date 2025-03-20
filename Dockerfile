# Etapa 1: Construcción de la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar archivos del proyecto y restaurar dependencias
COPY *.sln ./
COPY WebApp/*.csproj ./WebApp/
RUN dotnet restore WebApp/WebApp.csproj

# Copiar el código fuente y compilar
COPY . ./
WORKDIR /app/WebApp
RUN dotnet publish -c Release -o /publish

# Etapa 2: Imagen final para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]
