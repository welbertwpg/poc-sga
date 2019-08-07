using Microsoft.EntityFrameworkCore;
using System;

namespace Processos.Infra.Repositorios
{
    public abstract class RepositorioSql : IDisposable
    {
        protected readonly DbContext dbContext;
        public RepositorioSql(DbContext dbContext)
            => this.dbContext = dbContext;

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
