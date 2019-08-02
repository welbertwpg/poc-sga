using Ativos.Dominio.Entidades;

namespace Ativos.Dominio.Interfaces
{
    public interface IServicoAquisicoes
    {
        Ativo AdquirirAtivo(int id);
    }
}
