FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Ativos/Ativos.AgendadorManutencoes/Ativos.AgendadorManutencoes.csproj", "Ativos/Ativos.AgendadorManutencoes/"]
COPY ["Ativos/Ativos.Dominio/Ativos.Dominio.csproj", "Ativos/Ativos.Dominio/"]
COPY ["Ativos/Ativos.Infra/Ativos.Infra.csproj", "Ativos/Ativos.Infra/"]
RUN dotnet restore "Ativos/Ativos.AgendadorManutencoes/Ativos.AgendadorManutencoes.csproj"
COPY . .
WORKDIR "/src/Ativos/Ativos.AgendadorManutencoes"
RUN dotnet build "Ativos.AgendadorManutencoes.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ativos.AgendadorManutencoes.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ativos.AgendadorManutencoes.dll"]
