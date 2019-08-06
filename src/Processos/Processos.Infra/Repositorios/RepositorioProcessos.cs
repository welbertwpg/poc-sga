using Microsoft.EntityFrameworkCore;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Processos.Infra.Repositorios
{
    public class RepositorioProcessos : RepositorioSql, IRepositorioProcessos
    {
        private readonly DbSet<Processo> processos;
        public RepositorioProcessos(DbContext dbContext) : base(dbContext)
            => processos = dbContext.Set<Processo>();

        public void Deletar(Guid id)
        { 
            processos.Remove(processos.Find(id));
            dbContext.SaveChanges();
        }

        public void InserirOuAtualizar(Processo processo)
        {
            if (processos.Any(p => p.Identificador == processo.Identificador))
                processos.Update(processo);
            else
                processos.Add(processo);

            dbContext.SaveChanges();
        }

        public IEnumerable<Processo> Obter(int quantidade, int pagina)
            => processos.Skip(quantidade * (pagina - 1)).Take(quantidade);

        public Processo Obter(Guid id)
            => processos.Include(p => p.Etapas).FirstOrDefault(p => p.Identificador == id);
    }
}
