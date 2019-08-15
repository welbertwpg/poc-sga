using Ativos.Dominio.Entidades;
using Ativos.Dominio.Validacoes;
using FluentValidation;
using Xunit;

namespace Ativos.Testes
{
    public class ValidacaoCronograma
    {
        private readonly IValidator<CronogramaManutencao> validadorCronograma;

        public ValidacaoCronograma()
            => validadorCronograma = new ValidadorCronograma();

        [Fact]
        public void Validacao_CamposObrigatoriosPreenchidos_Valido()
        {
            var cronograma = new CronogramaManutencao
            {
                Frequencia = FrequenciaManutencao.Diaria,
                TipoAtivo = TipoAtivo.Equipamento
            };

            var resultadoValidacao = validadorCronograma.Validate(cronograma);
            Assert.True(resultadoValidacao.IsValid);
        }

        [Fact]
        public void Validacao_CamposObrigatoriosNaoPreenchidos_Invalido()
        {
            var cronograma = new CronogramaManutencao { };
            var resultadoValidacao = validadorCronograma.Validate(cronograma);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(2, resultadoValidacao.Errors.Count);
        }

        [Fact]
        public void Validacao_IntervaloHorasUsoFrequenciaValida_Valido()
        {
            var cronograma = new CronogramaManutencao
            {
                Frequencia = FrequenciaManutencao.Intervalo,
                IntervaloHorasUso = 2,
                TipoAtivo = TipoAtivo.Equipamento
            };

            var resultadoValidacao = validadorCronograma.Validate(cronograma);
            Assert.True(resultadoValidacao.IsValid);
        }

        [Fact]
        public void Validacao_IntervaloHorasUsoFrequenciaInvalida_Invalido()
        {
            var cronograma = new CronogramaManutencao
            {
                Frequencia = FrequenciaManutencao.Diaria,
                IntervaloHorasUso = 2,
                TipoAtivo = TipoAtivo.Equipamento
            };

            var resultadoValidacao = validadorCronograma.Validate(cronograma);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(1, resultadoValidacao.Errors.Count);
        }

        [Fact]
        public void Validacao_IntervaloHorasUsoNegativoFrequenciaValida_Invalido()
        {
            var cronograma = new CronogramaManutencao
            {
                Frequencia = FrequenciaManutencao.Intervalo,
                IntervaloHorasUso = -2,
                TipoAtivo = TipoAtivo.Equipamento
            };

            var resultadoValidacao = validadorCronograma.Validate(cronograma);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(1, resultadoValidacao.Errors.Count);
        }
    }
}
