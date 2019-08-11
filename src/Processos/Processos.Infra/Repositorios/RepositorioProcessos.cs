using Dapper;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Processos.Infra.Repositorios
{
    public class RepositorioProcessos : RepositorioSql, IRepositorioProcessos
    {
        public RepositorioProcessos(IDbConnection dbConnection) : base(dbConnection) { }

        public void Deletar(Guid id)
            => dbConnection.Execute("DELETE Processos WHERE Identificador = @id", new { id });

        public void InserirOuAtualizar(Processo processo)
        {
            var registros = dbConnection.QueryFirstOrDefault<int>("SELECT COUNT(Identificador) FROM Processos WHERE Identificador = @Identificador", new { processo.Identificador });
            if (registros > 0)
                Atualizar(processo);
            else
                Inserir(processo);
        }

        private void Inserir(Processo processo)
        {
            dbConnection.Open();
            using (var transacao = dbConnection.BeginTransaction())
            {
                dbConnection.Execute("INSERT INTO Processos (Identificador, Nome) " +
                    "VALUES (@Identificador, @Nome)", new
                    {
                        processo.Identificador,
                        processo.Nome
                    }, transacao);

                foreach (var etapa in processo.Etapas)
                {
                    dbConnection.Execute("INSERT INTO Etapas (Identificador, IdentificadorProcesso, Nome, Tipo, X, Y)" +
                        "VALUES (@Identificador, @IdentificadorProcesso, @Nome, @Tipo, @X, @Y)", new
                        {
                            etapa.Identificador,
                            IdentificadorProcesso = processo.Identificador,
                            etapa.Nome,
                            etapa.Tipo,
                            etapa.X,
                            etapa.Y
                        }, transacao);
                }

                foreach (var etapa in processo.Etapas)
                    foreach (var saida in etapa.EtapasSaida)
                    {
                        dbConnection.Execute("INSERT INTO EtapaReferencia (IdentificadorEtapaEntrada, IdentificadorEtapaSaida)"
                            + "VALUES (@Identificador, @saida)", new { etapa.Identificador, saida }, transacao);
                    }

                transacao.Commit();
            }
        }

        private void Atualizar(Processo processo)
        {
        }

        public IEnumerable<Processo> Obter(int quantidade, int pagina)
            => dbConnection.Query<Processo>("SELECT ");

        public Processo Obter(Guid id)
            => dbConnection.QuerySingleOrDefault<Processo>("SELECT ", new { id });
    }
}
