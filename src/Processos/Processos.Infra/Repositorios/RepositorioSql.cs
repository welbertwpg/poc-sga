using Microsoft.EntityFrameworkCore;

namespace Processos.Infra.Repositorios
{
    public abstract class RepositorioSql
    {
        protected readonly DbContext dbContext;
        public RepositorioSql(DbContext dbContext)
            => this.dbContext = dbContext;
    }
}
