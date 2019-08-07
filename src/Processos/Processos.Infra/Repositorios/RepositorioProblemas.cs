using Microsoft.EntityFrameworkCore;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;

namespace Processos.Infra.Repositorios
{
    public class RepositorioProblemas : RepositorioSql, IRepositorioProblemas
    {
        private readonly DbSet<Problema> problemas;
        public RepositorioProblemas(DbContext dbContext) : base(dbContext)
            => problemas = dbContext.Set<Problema>();

        public void Inserir(Problema problema)
        {
            problemas.Add(problema);
            dbContext.SaveChanges();
        }
    }
}
