using Monitoramento.Dominio.Interfaces;
using Monitoramento.Dominio.Entidades;
using System;

namespace Monitoramento.Infra.Servicos
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
