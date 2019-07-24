using AtivosApi.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace AtivosApi.Database.Interfaces
{
    public interface IRepositorioAtivos
    {
        void Inserir(Ativo ativo);
        void Atualizar(Ativo ativo);
        void Deletar(ObjectId id);
        Ativo Obter(ObjectId id);
        IEnumerable<Ativo> Obter();
    }
}
