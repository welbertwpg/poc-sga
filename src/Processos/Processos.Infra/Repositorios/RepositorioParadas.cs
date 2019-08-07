using Microsoft.EntityFrameworkCore;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;

namespace Processos.Infra.Repositorios
{
    public class RepositorioParadas : RepositorioSql, IRepositorioParadas
    {
        private DbSet<Parada> paradas;
        public RepositorioParadas(DbContext dbContext) : base(dbContext)
            => paradas = dbContext.Set<Parada>();

        public void Inserir(Parada parada)
        {
            paradas.Add(parada);
            dbContext.SaveChanges();
        }
    }
}
