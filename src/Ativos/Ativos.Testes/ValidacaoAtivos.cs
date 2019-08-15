using Ativos.Dominio.Entidades;
using Ativos.Dominio.Validacoes;
using FluentValidation;
using System;
using Xunit;

namespace Ativos.Testes
{
    public class ValidacaoAtivos
    {
        private readonly IValidator<Ativo> validadorAtivo;

        public ValidacaoAtivos()
            => validadorAtivo = new ValidadorAtivo();

        [Fact]
        public void Validacao_CamposObrigatoriosPreenchidos_Valido()
        {
            var ativo = new Ativo
            {
                DataAquisicao = DateTime.Now,
                MediaHorasUsoDiariamente = 3,
                Nome = "Nome de teste",
                Patrimonio = "43545634",
                Tipo = TipoAtivo.Equipamento
            };

            var resultadoValidacao = validadorAtivo.Validate(ativo);
            Assert.True(resultadoValidacao.IsValid);
        }

        [Fact]
        public void Validacao_CamposObrigatoriosNaoPreenchidos_InvalidoComErros()
        {
            var ativo = new Ativo { };
            var resultadoValidacao = validadorAtivo.Validate(ativo);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(6, resultadoValidacao.Errors.Count);
        }

        [Fact]
        public void Validacao_MediaHorasUsoDiariamenteNegativo_InvalidoComErro()
        {
            var ativo = new Ativo
            {
                DataAquisicao = DateTime.Now,
                MediaHorasUsoDiariamente = -12443,
                Nome = "Nome de teste",
                Patrimonio = "43545634",
                Tipo = TipoAtivo.Equipamento
            };

            var resultadoValidacao = validadorAtivo.Validate(ativo);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(1, resultadoValidacao.Errors.Count);
        }
    }
}
