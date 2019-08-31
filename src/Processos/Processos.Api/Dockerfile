FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Processos/Processos.Api/Processos.Api.csproj", "Processos/Processos.Api/"]
COPY ["Processos/Processos.Dominio/Processos.Dominio.csproj", "Processos/Processos.Dominio/"]
COPY ["Processos/Processos.Infra/Processos.Infra.csproj", "Processos/Processos.Infra/"]
RUN dotnet restore "Processos/Processos.Api/Processos.Api.csproj"
COPY . .
WORKDIR "/src/Processos/Processos.Api"
RUN dotnet build "Processos.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Processos.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Processos.Api.dll"]
