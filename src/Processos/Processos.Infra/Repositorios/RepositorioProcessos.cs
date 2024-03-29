﻿using Dapper;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Processos.Infra.Repositorios
{
    public class RepositorioProcessos : RepositorioSql, IRepositorioProcessos
    {
        public RepositorioProcessos(IDbConnection dbConnection) : base(dbConnection) { }

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
                Inserir(processo, transacao);
                transacao.Commit();
            }
        }

        private void Inserir(Processo processo, IDbTransaction transacao)
        {
            dbConnection.Execute("INSERT INTO Processos (Identificador, Nome) " +
                "VALUES (@Identificador, @Nome)", new
                {
                    processo.Identificador,
                    processo.Nome
                }, transacao);

            foreach (var etapa in processo.Etapas)
            {
                dbConnection.Execute("INSERT INTO Etapas (Identificador, IdentificadorProcesso, Nome, Tipo)" +
                    "VALUES (@Identificador, @IdentificadorProcesso, @Nome, @Tipo)", new
                    {
                        etapa.Identificador,
                        IdentificadorProcesso = processo.Identificador,
                        etapa.Nome,
                        etapa.Tipo,
                    }, transacao);
            }

            foreach (var etapa in processo.Etapas)
                foreach (var saida in etapa.EtapasSaida)
                {
                    dbConnection.Execute("INSERT INTO EtapaReferencia (IdentificadorEtapaEntrada, IdentificadorEtapaSaida)"
                        + "VALUES (@Identificador, @saida)", new { etapa.Identificador, saida }, transacao);
                }
        }

        private void Atualizar(Processo processo)
        {
            dbConnection.Open();
            using (var transacao = dbConnection.BeginTransaction())
            {
                Deletar(processo.Identificador, transacao);
                Inserir(processo, transacao);
                transacao.Commit();
            }
        }

        public IEnumerable<Processo> Obter()
            => dbConnection.Query<Processo>("SELECT Identificador, Nome FROM Processos");

        public Processo Obter(Guid id)
        {
            var resultado = dbConnection.Query<dynamic>(@"
                SELECT
                    P.Identificador,
                    P.Nome,
                    E.Identificador Etapas_Identificador,
                    E.Tipo Etapas_Tipo,
                    E.Nome Etapas_Nome,
                    ER.IdentificadorEtapaSaida Etapas_EtapasSaida_$
                FROM Processos P
                JOIN Etapas E ON P.Identificador = E.IdentificadorProcesso
                LEFT JOIN EtapaReferencia ER ON E.Identificador = ER.IdentificadorEtapaEntrada
                WHERE P.Identificador = @id
                ORDER BY E.Tipo", new { id });

            AutoMapper.Configuration.AddIdentifier(typeof(Processo), "Identificador");
            AutoMapper.Configuration.AddIdentifier(typeof(Etapa), "Identificador");

            return AutoMapper.MapDynamic<Processo>(resultado, false).FirstOrDefault();
        }

        public void Deletar(Guid id)
        {
            dbConnection.Open();
            using (var transacao = dbConnection.BeginTransaction())
            {
                Deletar(id, transacao);
                transacao.Commit();
            }
        }

        private void Deletar(Guid id, IDbTransaction transacao)
            => dbConnection.Execute("DELETE Processos WHERE Identificador = @id", new { id }, transacao);
    }
}
