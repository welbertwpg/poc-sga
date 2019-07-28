using Ativos.Dominio.Models;
using Ativos.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Serilog;
using System;
using System.Linq;
using System.Threading;

namespace Ativos.AgendadorManutencoes
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

            var mongoDb = new MongoClient(configuration.GetConnectionString("MongoDB"));
            var repositorioCronogramas = new RepositorioCronogramasMongoDB(mongoDb);
            var repositorioAtivos = new RepositorioAtivosMongoDB(mongoDb);
            var intervalo = Convert.ToInt32(configuration["Intervalo"]);

            while (true)
            {
                logger.Information("Executando agendador");

                var cronogramas = repositorioCronogramas.Obter();
                logger.Information($"{cronogramas.Count()} cronogramas cadastrados");

                var ativos = repositorioAtivos.Obter().ToList();
                logger.Information($"{ativos.Count} ativos cadastrados");

                foreach (var cronograma in cronogramas)
                {
                    var ativosEnquadrados = ativos.Where(a => !a.Manutencoes.Any(m => !m.Realizada) && cronograma.VerificarManutencaoNecessaria(a.ObterDataUltimaManutencao(), a.ObterHorasUso())).ToList();
                    foreach(var ativo in ativosEnquadrados)
                    {
                        var manutencao = new Manutencao
                        {
                            Tipo = TipoManutencao.Preventiva,
                            DataHora = cronograma.ObterDataProximaManutencao()
                        };
                        repositorioAtivos.Inserir(ativo.Identificador, manutencao);
                        logger.Information($"Manutenção '{manutencao.Identificador}' criada para o ativo '{ativo.Identificador}' através do cronograma '{cronograma.Identificador}'");

                        //Remove para não cair no processamento de outro cronograma
                        ativos.Remove(ativo);
                    }
                }

                logger.Information($"Agendador finalizou a execução, próxima execução em {intervalo}ms");
                Thread.Sleep(intervalo);
            }
        }
    }
}
