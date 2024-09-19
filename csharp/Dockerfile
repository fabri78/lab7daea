# Fase de construcción
FROM mcr.microsoft.com/dotnet/sdk:8:0 AS build
WORKDIR /src
COPY CSharpApp.csproj .
RUN dotnet restore CSharpApp.csproj
COPY . .
RUN dotnet build CSharpApp.csproj -c Release -o /app

# Fase final
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "CSharpApp.dll"]
