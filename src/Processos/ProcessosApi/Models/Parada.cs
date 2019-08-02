using System;

namespace ProcessosApi.Models
{
    public class Parada
    {
        public Guid Identificador { get; set; }
        public DateTime Data { get; set; }
        public Turno Turno { get; set; }
        public string Descricao { get; set; }
        public Guid? Etapa { get; set; }
    }
}
