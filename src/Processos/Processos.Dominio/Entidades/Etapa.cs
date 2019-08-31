using System;
using System.Collections.Generic;

namespace Processos.Dominio.Entidades
{
    public class Etapa
    {
        public Etapa()
        {
            EtapasSaida = new List<Guid>();
        }

        public Guid Identificador { get; set; }
        public TipoEtapa Tipo { get; set; }
        public string Nome { get; set; }
        public ICollection<Guid> EtapasSaida { get; set; }
    }
}