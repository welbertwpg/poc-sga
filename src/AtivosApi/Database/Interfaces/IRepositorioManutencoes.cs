using AtivosApi.Models;
using System;

namespace AtivosApi.Database.Interfaces
{
    public interface IRepositorioManutencoes
    {
        void Inserir(Guid id, Manutencao manutencao);
    }
}
