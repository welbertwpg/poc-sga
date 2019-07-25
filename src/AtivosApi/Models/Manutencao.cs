using System;

namespace AtivosApi.Models
{
    public class Manutencao
    {
        public Manutencao()
        {
            Identificador = Guid.NewGuid();
            Realizada = false;
        }

        public Guid Identificador { get; set; }
        public DateTime DataHora { get; set; }
        public TipoManutencao TipoManutencao { get; set; }
        public bool Realizada { get; set; }
    }
}
