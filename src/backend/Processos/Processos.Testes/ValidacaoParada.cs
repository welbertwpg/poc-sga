using FluentValidation;
using Processos.Dominio.Entidades;
using Processos.Dominio.Validacoes;
using System;
using Xunit;

namespace Processos.Testes
{
    public class ValidacaoParada
    {
        private readonly IValidator<Parada> validadorParada = new ValidadorParada();

        [Fact]
        public void ValidacaoParada_CamposObrigatoriosPreenchidos_Valido()
        {
            var parada = new Parada
            {
                Data = DateTime.Now,
                IdentificadorProcesso = Guid.NewGuid(),
                Descricao = "Parada de teste",
                Turno = Turno.Manha
            };

            var resultadoValidacao = validadorParada.Validate(parada);
            Assert.True(resultadoValidacao.IsValid);
        }

        [Fact]
        public void ValidacaoParada_CamposObrigatoriosNaoPreenchidos_Invalido()
        {
            var parada = new Parada { };
            var resultadoValidacao = validadorParada.Validate(parada);
            Assert.False(resultadoValidacao.IsValid);
            Assert.Equal(4, resultadoValidacao.Errors.Count);
        }
    }
}
