﻿namespace Monitoramento.Dominio.Entidades
{
    public class Alerta
    {
        public string Mensagem { get; set; }
        public CriticidadeAlerta Criticidade { get; set; }
    }
}
