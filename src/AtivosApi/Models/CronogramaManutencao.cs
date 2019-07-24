using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtivosApi.Models
{
    public class CronogramaManutencao
    {
        public FrequenciaManutencao Frequencia { get; set; }
        public TipoAtivo TipoAtivo { get; set; }
        public int IntervaloHorasUso { get; set; }
    }
}
