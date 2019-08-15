namespace Monitoramento.Dominio.Entidades
{
    public class ResultadoSensores
    {
        public ResultadoPiezometro Piezometro { get; set; }
        public ResultadoSensorDeslocamento Deslocamento { get; set; }

        public bool Validar(Limites limites)
            => Piezometro.Nivel <= limites.NivelMaximoPermitido && Piezometro.Pressao <= limites.PressaoMaximaPermitida;
    }
}
