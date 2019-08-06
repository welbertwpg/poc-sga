using System;
using System.Collections.Generic;

namespace Processos.Dominio.Entidades
{
    public class Etapa
    {
        public Guid Identificador { get; set; }
        public TipoEtapa Tipo { get; set; }
        public string Nome { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Processo Processo { get; set; }
        public Etapa EtapaEntrada { get; set; }
        public IEnumerable<Etapa> EtapasSaida { get; set; }
        public IEnumerable<Problema> Problemas { get; set; }
        public IEnumerable<Parada> Paradas { get; set; }
    }
}