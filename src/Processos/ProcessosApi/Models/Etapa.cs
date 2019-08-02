﻿using System;
using System.Collections.Generic;

namespace ProcessosApi.Models
{
    public class Etapa
    {
        public Guid Id { get; set; }
        public TipoEtapa Tipo { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Guid> EtapasReferenciadas { get; set; }
    }
}