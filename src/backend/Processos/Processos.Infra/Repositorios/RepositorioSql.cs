using System;
using System.Data;

namespace Processos.Infra.Repositorios
{
    public abstract class RepositorioSql : IDisposable
    {
        protected readonly IDbConnection dbConnection;

        public RepositorioSql(IDbConnection dbConnection)
            => this.dbConnection = dbConnection;

        public void Dispose()
        {
            dbConnection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
