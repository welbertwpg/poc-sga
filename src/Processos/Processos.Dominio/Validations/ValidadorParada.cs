using FluentValidation;
using Processos.Dominio.Models;

namespace Processos.Dominio.Validations
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
