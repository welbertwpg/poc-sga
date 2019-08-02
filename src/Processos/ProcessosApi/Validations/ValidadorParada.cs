using FluentValidation;
using ProcessosApi.Models;

namespace ProcessosApi.Validations
{
    public class ValidadorParada : AbstractValidator<Parada>
    {
        public ValidadorParada()
        {
            RuleFor(p => p.Identificador)
                .NotEmpty()
                .WithMessage("'Identificador' obrigatório");

            RuleFor(p => p.Data)
                .NotEmpty()
                .WithMessage("'Data' obrigatória");

            RuleFor(p => p.Turno)
                .NotEmpty()
                .WithMessage("'Turno' obrigatório");

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("'Descricao' obrigatória");
        }
    }
}
