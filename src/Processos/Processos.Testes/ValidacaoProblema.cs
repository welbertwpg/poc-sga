using FluentValidation;
using Processos.Dominio.Entidades;
using Processos.Dominio.Validacoes;
using System;
using Xunit;

namespace Processos.Testes
{
    public class ValidacaoProblema
    {
        private readonly IValidator<Problema> validadorProblema = new ValidadorProblema();

        [Fact]
        public void ValidacaoProblema_CamposObrigatoriosPreenchidos_Valido()
        {
            var problema = new Problema
            {
                Data = DateTime.Now,
                IdentificadorProcesso = Guid.NewGuid(),
                Descricao = "Problema de teste",
                Turno = Turno.Manha
            };

            var resultadoValidacao = validadorProblema.Validate(problema);
            Assert.True(resultadoValidacao.IsValid);
        }

        [Fact]
        public void ValidacaoProblema_CamposObrigatoriosNaoPreenchidos_Invalido()
        {
            var problema = new Problema { };
            var resultadoValidacao = validadorProblema.Validate(problema);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(4, resultadoValidacao.Errors.Count);
        }
    }
}
