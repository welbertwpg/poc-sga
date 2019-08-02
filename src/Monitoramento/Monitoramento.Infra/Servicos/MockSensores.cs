using Monitoramento.Dominio.Interfaces;
using Monitoramento.Dominio.Entidades;
using System;

namespace Monitoramento.Infra.Servicos
{
    public class MockSensores : ISensores
    {
        public ResultadoSensores Obter()
        {
            var random = new Random();
            return new ResultadoSensores
            {
                Deslocamento = new ResultadoSensorDeslocamento
                {
                    DeslocamentoHorizontal = random.NextDouble(),
                    DeslocamentoVertical = random.NextDouble()
                },
                Piezometro = new ResultadoPiezometro
                {
                    Nivel = random.NextDouble(),
                    Pressao = random.NextDouble()
                }
            };
        }
    }
}
