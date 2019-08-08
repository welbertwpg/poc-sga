using System;
using System.Collections.Generic;

namespace Processos.Dominio.Entidades
{
    public class Processo
    {
        public Processo()
            => Identificador = Guid.NewGuid();

        public Guid Identificador { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Etapa> Etapas { get; set; }
    }
}
