using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Monitoramento.Dominio.Interfaces;
using Monitoramento.Infra.Services;
using Serilog;
using System;
using System.Threading;

namespace AtualizadorMonitoramento
{
    class Program
    {
        async static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var endpointSingnalr = configuration["Signalr.Endpoint"];
            var conexao = new HubConnectionBuilder()
                .WithUrl(endpointSingnalr)
                .Build();

            conexao.Closed += async (error) =>
            {
                logger.Information("Conexão encerrada, reconectando");
                await conexao.StartAsync();
            };

            logger.Information($"Conectando no endereço {endpointSingnalr}");
            await conexao.StartAsync();
            logger.Information("Conectado");

            var intervalo = Convert.ToInt32(configuration["Intervalo"]);
            logger.Information($"Tempo de atualização: {intervalo}");

            ISensores sensores = new MockSensores();
            while (true)
            {
                var resultado = sensores.Obter();
                await conexao.InvokeAsync("AtualizarResultadosSensores", resultado);
                Thread.Sleep(intervalo);
            }
        }
    }
}
