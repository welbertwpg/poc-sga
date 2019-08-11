using System.Data;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;

namespace Processos.Infra.Repositorios
{
    public class RepositorioParadas : RepositorioSql, IRepositorioParadas
    {
        public RepositorioParadas(IDbConnection dbConnection) : base(dbConnection) { }

        public void Inserir(Parada parada)
        {
            throw new System.NotImplementedException();
        }
    }
}
