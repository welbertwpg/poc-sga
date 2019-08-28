using System.Data;
using Dapper;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;

namespace Processos.Infra.Repositorios
{
    public class RepositorioProblemas : RepositorioSql, IRepositorioProblemas
    {
        public RepositorioProblemas(IDbConnection dbConnection) : base(dbConnection) { }

        public void Inserir(Problema problema)
            => dbConnection.Execute(@"INSERT INTO Problemas(Identificador, IdentificadorProcesso, Data, Turno, Descricao, IdentificadorEtapa)
                                        VALUES (@Identificador, @IdentificadorProcesso, @Data, @Turno, @Descricao, @IdentificadorEtapa)", problema);
    }
}
