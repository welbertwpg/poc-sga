using System.Data;
using Dapper;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;

namespace Processos.Infra.Repositorios
{
    public class RepositorioParadas : RepositorioSql, IRepositorioParadas
    {
        public RepositorioParadas(IDbConnection dbConnection) : base(dbConnection) { }

        public void Inserir(Parada parada)
            => dbConnection.Execute(@"INSERT INTO Paradas(Identificador, IdentificadorProcesso, Data, Turno, Descricao, IdentificadorEtapa)
                                        VALUES (@Identificador, @IdentificadorProcesso, @Data, @Turno, @Descricao, @IdentificadorEtapa)", parada);
    }
}
