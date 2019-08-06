using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Processos.Infra.Contexto
{
    public class ContextoProcessos : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}
