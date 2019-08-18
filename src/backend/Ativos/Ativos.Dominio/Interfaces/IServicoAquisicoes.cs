using Ativos.Dominio.Entidades;
using System.Collections.Generic;

namespace Ativos.Dominio.Interfaces
{
    public interface IServicoAquisicoes
    {
        IEnumerable<Adquirivel> ObterAdquiriveis();
        Ativo AdquirirAtivo(int id);
    }
}
