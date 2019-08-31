FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Monitoramento/Monitoramento.Atualizador/Monitoramento.Atualizador.csproj", "Monitoramento/Monitoramento.Atualizador/"]
COPY ["Monitoramento/Monitoramento.Infra/Monitoramento.Infra.csproj", "Monitoramento/Monitoramento.Infra/"]
COPY ["Monitoramento/Monitoramento.Dominio/Monitoramento.Dominio.csproj", "Monitoramento/Monitoramento.Dominio/"]
RUN dotnet restore "Monitoramento/Monitoramento.Atualizador/Monitoramento.Atualizador.csproj"
COPY . .
WORKDIR "/src/Monitoramento/Monitoramento.Atualizador"
RUN dotnet build "Monitoramento.Atualizador.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Monitoramento.Atualizador.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Monitoramento.Atualizador.dll"]
