using System;

namespace Processos.Dominio.Models
{
    public class Problema
    {
        public Guid Identificador { get; set; }
        public DateTime Data { get; set; }
        public Turno Turno { get; set; }
        public string Descricao { get; set; }
        public Guid? Etapa { get; set; }
    }
}
