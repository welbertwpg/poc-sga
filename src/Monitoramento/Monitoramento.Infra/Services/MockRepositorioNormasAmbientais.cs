using Monitoramento.Dominio.Interfaces;
using Monitoramento.Dominio.Models;
using System;

namespace Monitoramento.Infra.Services
{
    public class MockRepositorioNormasAmbientais : IRepositorioNormasAmbientais
    {
        public NormasAmbientais Obter()
        {
            var random = new Random();
            return new NormasAmbientais
            {
                NivelMaximoPermitido = random.NextDouble(),
                PressaoMaximaPermitida = random.NextDouble()
            };
        }
    }
}
