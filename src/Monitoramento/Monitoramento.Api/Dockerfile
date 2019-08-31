FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Monitoramento/Monitoramento.Api/Monitoramento.Api.csproj", "Monitoramento/Monitoramento.Api/"]
COPY ["Monitoramento/Monitoramento.Infra/Monitoramento.Infra.csproj", "Monitoramento/Monitoramento.Infra/"]
COPY ["Monitoramento/Monitoramento.Dominio/Monitoramento.Dominio.csproj", "Monitoramento/Monitoramento.Dominio/"]
RUN dotnet restore "Monitoramento/Monitoramento.Api/Monitoramento.Api.csproj"
COPY . .
WORKDIR "/src/Monitoramento/Monitoramento.Api"
RUN dotnet build "Monitoramento.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Monitoramento.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Monitoramento.Api.dll"]
