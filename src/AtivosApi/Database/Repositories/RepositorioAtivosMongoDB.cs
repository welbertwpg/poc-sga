using AtivosApi.Database.Interfaces;
using AtivosApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AtivosApi.Database.Repositories
{
    public class RepositorioAtivosMongoDB : IRepositorioAtivos
    {
        private readonly IMongoCollection<Ativo> ativos;

        public RepositorioAtivosMongoDB(IMongoClient cliente)
            => ativos = cliente.GetDatabase("sga").GetCollection<Ativo>("ativos");

        public void Atualizar(Ativo ativo)
            => ativos.ReplaceOne(a => a.Identificador == ativo.Identificador, ativo);

        public void Deletar(Guid id)
            => ativos.DeleteOne(a => a.Identificador == id);

        public void Inserir(Ativo ativo)
            => ativos.InsertOne(ativo);

        public void InserirManutencao(Guid id, Manutencao manutencao)
        {
            var atualizacao = Builders<Ativo>.Update.Push(a => a.Manutencoes, manutencao);
            ativos.UpdateOne(a => a.Identificador == id, atualizacao);
        }

        public Ativo Obter(Guid id)
            => ativos.Find(a => a.Identificador == id).Single();

        public IEnumerable<Ativo> Obter()
            => ativos.Find(Builders<Ativo>.Filter.Empty).ToList();
    }
}
