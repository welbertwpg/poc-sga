using AtivosApi.Models;
using FluentValidation;

namespace AtivosApi.Validations
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
        }
    }
}
