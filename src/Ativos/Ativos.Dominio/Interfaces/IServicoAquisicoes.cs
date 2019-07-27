using Ativos.Dominio.Models;

namespace Ativos.Dominio.Interfaces
{
    public interface IServicoAquisicoes
    {
        Ativo AdquirirAtivo(int id);
    }
}
