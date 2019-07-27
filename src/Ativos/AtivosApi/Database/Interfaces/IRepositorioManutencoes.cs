using AtivosApi.Models;
using MongoDB.Bson;

namespace AtivosApi.Database.Interfaces
{
    public interface IRepositorioManutencoes
    {
        void Inserir(ObjectId id, Manutencao manutencao);

        void AtualizarStatus(ObjectId id, ObjectId idManutencao, bool status);
    }
}
