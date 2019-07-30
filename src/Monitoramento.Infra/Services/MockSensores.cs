using Monitoramento.Dominio.Interfaces;
using Monitoramento.Dominio.Models;
using System;

namespace Monitoramento.Infra.Services
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
