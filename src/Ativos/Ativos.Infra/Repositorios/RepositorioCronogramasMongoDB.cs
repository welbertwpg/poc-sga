using Ativos.Dominio.Interfaces;
using Ativos.Dominio.Entidades;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Ativos.Infra.Repositorios
{
    public class RepositorioCronogramasMongoDB : IRepositorioCronogramas
    {
        private readonly IMongoCollection<CronogramaManutencao> cronogramas;

        public RepositorioCronogramasMongoDB(IMongoClient cliente)
            => cronogramas = cliente.GetDatabase("sga").GetCollection<CronogramaManutencao>("cronogramas");

        public void Deletar(ObjectId id)
            => cronogramas.DeleteOne(c => c.Identificador == id);

        public void Inserir(CronogramaManutencao cronograma)
            => cronogramas.InsertOne(cronograma);

        public IEnumerable<CronogramaManutencao> Obter()
            => cronogramas.Find(Builders<CronogramaManutencao>.Filter.Empty).ToList();
    }
}
