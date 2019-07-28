using Ativos.Dominio.Models;
using FluentValidation;
using System;

namespace Ativos.Dominio.Validations
{
    public class ValidadorManutencao : AbstractValidator<Manutencao>
    {
        public ValidadorManutencao()
        {
            RuleFor(m => m.Identificador)
                .NotEmpty()
                .WithMessage("'Identificador' obrigatório");

            RuleFor(m => m.DataHora)
                .NotEmpty()
                .WithMessage("'DataHora' obrigatório");

            RuleFor(m => m.Tipo)
                .NotEmpty()
                .WithMessage("'Tipo' obrigatório");

            RuleFor(m => m.DataHora)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("'DataHora' deve ser maior que a data atual");
        }
    }
}
