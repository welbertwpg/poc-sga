using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Monitoramento.Dominio.Interfaces;
using Monitoramento.Infra.Servicos;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading;

namespace Monitoramento.Atualizador
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var endpointSignalr = configuration["Signalr.Endpoint"];
            var conexao = new HubConnectionBuilder()
                .WithUrl(endpointSignalr)
                .Build();

            conexao.Closed += async (error) =>
            {
                logger.Information("Conexão encerrada, reconectando");
                await conexao.StartAsync();
            };

            logger.Information($"Conectando no endereço {endpointSignalr}");

            conectar:
            try
            {
                conexao.StartAsync().Wait();
            }
            catch
            {
                Thread.Sleep(1000);
                goto conectar;
            }

            logger.Information("Conectado");

            var intervalo = Convert.ToInt32(configuration["Intervalo"]);
            logger.Information($"Tempo de atualização: {intervalo}ms");

            ISensores sensores = new MockSensores();
            while (true)
            {
                var resultado = sensores.Obter();
                var resultadoJson = JsonConvert.SerializeObject(resultado);
                logger.Information($"Novo resultado: {resultadoJson}");

                conexao.InvokeAsync("AtualizarResultadosSensores", resultado).Wait();
                logger.Information("Enviado para o SignalR");

                Thread.Sleep(intervalo);
            }
        }
    }
}
