using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Processos.Infra.Contexto
{
    public class ContextoProcessos : DbContext
    {
        protected ContextoProcessos() : base() { }
        public ContextoProcessos(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Processos.Infra")) ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
