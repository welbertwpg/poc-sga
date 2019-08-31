using Ativos.Dominio.Entidades;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Ativos.Dominio.Interfaces
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
