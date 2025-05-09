# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivos del proyecto
COPY MarcasAutosApi/*.csproj ./MarcasAutosApi/
WORKDIR /src/MarcasAutosApi
RUN dotnet restore

# Copiar el resto de los archivos y compilar
COPY MarcasAutosApi/. ./
RUN dotnet publish -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "MarcasAutosApi.dll"]
