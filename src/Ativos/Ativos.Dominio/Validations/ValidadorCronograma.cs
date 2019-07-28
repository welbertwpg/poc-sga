using Ativos.Dominio.Models;
using FluentValidation;

namespace Ativos.Dominio.Validations
{
    public class ValidadorCronograma : AbstractValidator<CronogramaManutencao>
    {
        public ValidadorCronograma()
        {
            RuleFor(c => c.Identificador)
                .NotEmpty()
                .WithMessage("'Identificador' obrigatório");

            RuleFor(c => c.TipoAtivo)
                .NotEmpty()
                .WithMessage("'TipoAtivo' obrigatório");

            RuleFor(c => c.Frequencia)
                .NotEmpty()
                .WithMessage("'Frequencia' obrigatório");

            RuleFor(c => c.IntervaloHorasUso)
                .NotEmpty()
                .GreaterThan(0)
                .When(c => c.Frequencia == FrequenciaManutencao.Intervalo)
                .WithMessage("'IntervaloHorasUso' deve ser um número positivo");

            RuleFor(c => c.IntervaloHorasUso)
                .Empty()
                .When(c => c.Frequencia != FrequenciaManutencao.Intervalo)
                .WithMessage("'IntervaloHorasUso' não deve ser preenchido para uma frequência determinada");
        }
    }
}
