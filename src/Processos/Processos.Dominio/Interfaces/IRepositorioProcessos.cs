using Processos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Processos.Dominio.Interfaces
{
    public interface IRepositorioProcessos
    {
        IEnumerable<Processo> Obter();
        Processo Obter(Guid id);
        void InserirOuAtualizar(Processo processo);
        void Deletar(Guid id);
    }
}
