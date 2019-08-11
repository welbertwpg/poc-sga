using System.Data;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;

namespace Processos.Infra.Repositorios
{
    public class RepositorioProblemas : RepositorioSql, IRepositorioProblemas
    {
        public RepositorioProblemas(IDbConnection dbConnection) : base(dbConnection) { }

        public void Inserir(Problema problema)
        {
            throw new System.NotImplementedException();
        }
    }
}
