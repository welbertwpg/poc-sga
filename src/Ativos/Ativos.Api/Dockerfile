FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Ativos/Ativos.Api/Ativos.Api.csproj", "Ativos/Ativos.Api/"]
COPY ["Ativos/Ativos.Dominio/Ativos.Dominio.csproj", "Ativos/Ativos.Dominio/"]
COPY ["Ativos/Ativos.Infra/Ativos.Infra.csproj", "Ativos/Ativos.Infra/"]
RUN dotnet restore "Ativos/Ativos.Api/Ativos.Api.csproj"
COPY . .
WORKDIR "/src/Ativos/Ativos.Api"
RUN dotnet build "Ativos.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ativos.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ativos.Api.dll"]
