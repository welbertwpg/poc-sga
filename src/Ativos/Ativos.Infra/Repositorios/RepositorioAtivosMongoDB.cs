using Ativos.Dominio.Interfaces;
using Ativos.Dominio.Entidades;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ativos.Infra.Repositorios
{
    public class RepositorioAtivosMongoDB : IRepositorioAtivos, IRepositorioManutencoes
    {
        private readonly IMongoCollection<Ativo> ativos;

        public RepositorioAtivosMongoDB(IMongoClient cliente)
            => ativos = cliente.GetDatabase("sga").GetCollection<Ativo>("ativos");

        public void Atualizar(Ativo ativo)
            => ativos.ReplaceOne(a => a.Identificador == ativo.Identificador, ativo);

        public void MarcarComoRealizada(ObjectId id, ObjectId idManutencao)
        {
            var filtro = Builders<Ativo>.Filter
                .And(Builders<Ativo>.Filter.Eq(a => a.Identificador, id),
                     Builders<Ativo>.Filter.ElemMatch(a => a.Manutencoes, m => m.Identificador == idManutencao && !m.Realizada));

            var atualizacao = Builders<Ativo>.Update
                .Set(a => a.Manutencoes[-1].Realizada, true)
                .Set(a => a.Manutencoes[-1].DataHoraRealizada, DateTime.Now);

            ativos.FindOneAndUpdate(filtro, atualizacao);
        }

        public void Deletar(ObjectId id)
            => ativos.DeleteOne(a => a.Identificador == id);

        public void Inserir(Ativo ativo)
            => ativos.InsertOne(ativo);

        public void Inserir(ObjectId id, Manutencao manutencao)
        {
            var atualizacao = Builders<Ativo>.Update.Push(a => a.Manutencoes, manutencao);
            ativos.UpdateOne(a => a.Identificador == id, atualizacao);
        }

        public Ativo Obter(ObjectId id)
            => ativos.Find(a => a.Identificador == id).SingleOrDefault();

        public IEnumerable<Ativo> Obter()
            => ativos.Find(Builders<Ativo>.Filter.Empty).ToList();
    }
}
