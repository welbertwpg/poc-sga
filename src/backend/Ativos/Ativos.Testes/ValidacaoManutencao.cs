using Ativos.Dominio.Entidades;
using Ativos.Dominio.Validacoes;
using FluentValidation;
using System;
using Xunit;

namespace Ativos.Testes
{
    public class ValidacaoManutencao
    {
        private readonly IValidator<Manutencao> validadorManutencao = new ValidadorManutencao();

        [Fact]
        public void ValidacaoCronograma_CamposObrigatoriosPreenchidos_Valido()
        {
            var manutencao = new Manutencao
            {
                Tipo = TipoManutencao.Corretiva,
                DataHora = DateTime.Now.AddDays(1)
            };

            var resultadoValidacao = validadorManutencao.Validate(manutencao);
            Assert.True(resultadoValidacao.IsValid);
        }

        [Fact]
        public void ValidacaoCronograma_CamposObrigatoriosNaoPreenchidos_Invalido()
        {
            var manutencao = new Manutencao { };
            var resultadoValidacao = validadorManutencao.Validate(manutencao);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(3, resultadoValidacao.Errors.Count);
        }

        [Fact]
        public void ValidacaoCronograma_DataHoraAntesDataAtual_Invalido()
        {
            var manutencao = new Manutencao
            {
                Tipo = TipoManutencao.Corretiva,
                DataHora = new DateTime(1990, 1, 1)
            };

            var resultadoValidacao = validadorManutencao.Validate(manutencao);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(1, resultadoValidacao.Errors.Count);
        }
    }
}
