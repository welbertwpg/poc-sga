using Ativos.Dominio.Entidades;
using Ativos.Dominio.Validacoes;
using FluentValidation;
using System;
using Xunit;

namespace Ativos.Testes
{
    public class ValidacaoAtivos
    {
        private readonly IValidator<Ativo> validadorAtivo = new ValidadorAtivo();

        [Fact]
        public void ValidacaoAtivos_CamposObrigatoriosPreenchidos_Valido()
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
        public void ValidacaoAtivos_CamposObrigatoriosNaoPreenchidos_Invalido()
        {
            var ativo = new Ativo { };
            var resultadoValidacao = validadorAtivo.Validate(ativo);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(6, resultadoValidacao.Errors.Count);
        }

        [Fact]
        public void ValidacaoAtivos_MediaHorasUsoDiariamenteNegativo_Invalido()
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
