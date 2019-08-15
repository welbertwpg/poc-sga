using Ativos.Dominio.Entidades;
using MongoDB.Bson;

namespace Ativos.Dominio.Interfaces
{
    public interface IRepositorioManutencoes
    {
        void Inserir(ObjectId id, Manutencao manutencao);

        void AtualizarStatus(ObjectId id, ObjectId idManutencao, bool status);
    }
}
