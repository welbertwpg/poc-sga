using System;
using System.Collections.Generic;

namespace Processos.Dominio.Entidades
{
    public class Etapa
    {
        public Guid Identificador { get; set; }
        public TipoEtapa Tipo { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Guid> EtapasReferenciadas { get; set; }
    }
}