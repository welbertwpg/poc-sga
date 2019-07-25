using AtivosApi.Models;
using System;
using System.Collections.Generic;

namespace AtivosApi.Database.Interfaces
{
    public interface IRepositorioAtivos
    {
        void Inserir(Ativo ativo);
        void Atualizar(Ativo ativo);
        void Deletar(Guid id);
        Ativo Obter(Guid id);
        IEnumerable<Ativo> Obter();
    }
}
