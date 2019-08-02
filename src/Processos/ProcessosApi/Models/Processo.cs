using System;
using System.Collections.Generic;

namespace ProcessosApi.Models
{
    public class Processo
    {
        public string Nome { get; set; }
        public IEnumerable<Etapa> Etapas { get; set; }
    }
}
