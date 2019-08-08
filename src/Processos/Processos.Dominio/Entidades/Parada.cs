﻿using System;

namespace Processos.Dominio.Entidades
{
    public class Parada
    {
        public Parada()
            => Identificador = Guid.NewGuid();

        public Guid Identificador { get; set; }
        public DateTime Data { get; set; }
        public Turno Turno { get; set; }
        public string Descricao { get; set; }
        public Etapa Etapa { get; set; }
    }
}
