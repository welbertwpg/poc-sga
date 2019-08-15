using Monitoramento.Dominio.Entidades;
using Xunit;

namespace Monitoramento.Testes
{
    public class Sensores
    {
        private readonly Limites limites = new Limites
        {
            NivelMaximoPermitido = 0.97,
            PressaoMaximaPermitida = 0.97
        };

        [Fact]
        public void ValidarSensores_ResultadoNaoAlterado_RetornaTrue()
        {
            var resultadoSensores = new ResultadoSensores
            {
                Deslocamento = new ResultadoSensorDeslocamento
                {
                    DeslocamentoHorizontal = 0.5,
                    DeslocamentoVertical = 0.4
                },
                Piezometro = new ResultadoPiezometro
                {
                    Nivel = 0.8,
                    Pressao = 0.8
                }
            };

            Assert.True(resultadoSensores.Validar(limites));
        }

        [Fact]
        public void ValidarSensores_ResultadoPressaoAlterada_RetornaFalse()
        {
            var resultadoSensores = new ResultadoSensores
            {
                Piezometro = new ResultadoPiezometro
                {
                    Nivel = 0.98,
                    Pressao = 0.8
                }
            };

            Assert.False(resultadoSensores.Validar(limites));
        }

        [Fact]
        public void ValidarSensores_ResultadoNivelAlterado_RetornaFalse()
        {
            var resultadoSensores = new ResultadoSensores
            {
                Piezometro = new ResultadoPiezometro
                {
                    Nivel = 0.8,
                    Pressao = 0.98
                }
            };

            Assert.False(resultadoSensores.Validar(limites));
        }

        [Fact]
        public void ValidarSensores_ResultadoNivelAlteradoPressaoAlterada_RetornaFalse()
        {
            var resultadoSensores = new ResultadoSensores
            {
                Piezometro = new ResultadoPiezometro
                {
                    Nivel = 0.98,
                    Pressao = 0.98
                }
            };

            Assert.False(resultadoSensores.Validar(limites));
        }
    }
}
