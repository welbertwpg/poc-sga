using Ativos.Dominio.Models;
using FluentValidation;

namespace Ativos.Dominio.Validations
{
    public class ValidadorCronograma : AbstractValidator<CronogramaManutencao>
    {
        public ValidadorCronograma()
        {
            RuleFor(m => m.Identificador)
                .NotEmpty()
                .WithMessage("'Identificador' obrigatório");

            RuleFor(m => m.TipoAtivo)
                .NotEmpty()
                .WithMessage("'TipoAtivo' obrigatório");

            RuleFor(m => m.Frequencia)
                .NotEmpty()
                .WithMessage("'Frequencia' obrigatório");

            RuleFor(a => a.IntervaloHorasUso)
                .GreaterThan(0)
                .WithMessage("'IntervaloHorasUso' deve ser um número positivo");
        }
    }
}
