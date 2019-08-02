using System;

namespace ProcessosApi.Models
{
    public class Problema
    {
        public Guid Identificador { get; set; }
        public DateTime Data { get; set; }
        public Turno Turno { get; set; }
        public string Descricao { get; set; }
    }
}
