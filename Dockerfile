FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build-env
WORKDIR /app

# Copiar csproj e restaurar dependencias
COPY AppTesteUnit.MVC/*.csproj ./
RUN dotnet restore

RUN pwsh -Command Write-Host "APIContagem: Gerando uma nova imagem Docker com Alpine e testando o PowerShell Core"

# Build da aplicacao
COPY AppTesteUnit.MVC ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80 443
ENTRYPOINT ["dotnet", "AppTesteUnit.MVC.dll"]
