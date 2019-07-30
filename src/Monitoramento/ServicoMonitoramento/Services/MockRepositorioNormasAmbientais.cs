using ServidorMonitoramento.Interfaces;
using ServidorMonitoramento.Models;
using System;

namespace ServidorMonitoramento.Services
{
    public class MockRepositorioNormasAmbientais : IRepositorioNormasAmbientais
    {
        public NormasAmbientais Obter()
        {
            var random = new Random();
            return new NormasAmbientais
            {
                DesvioMaximoPermitido = random.NextDouble(),
                NivelMaximoPermitido = random.NextDouble(),
                PressaoMaximaPermitida = random.NextDouble()
            };
        }
    }
}
