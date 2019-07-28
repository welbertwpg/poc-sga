using Ativos.Dominio.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Ativos.Dominio.Interfaces
{
    public interface IRepositorioCronogramas
    {
        IEnumerable<CronogramaManutencao> Obter();
        void Inserir(CronogramaManutencao cronograma);
        void Deletar(ObjectId id);
    }
}
