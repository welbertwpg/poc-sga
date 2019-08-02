using FluentValidation;
using ProcessosApi.Models;
using System.Linq;

namespace ProcessosApi.Validations
{
    public class ValidadorProcesso : AbstractValidator<Processo>
    {
        public ValidadorProcesso()
        {
            RuleFor(p => p.Identificador)
                .NotEmpty()
                .WithMessage("'Identificador' obrigatório");

            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("'Nome' obrigatório");

            RuleFor(p => p.Etapas)
                .NotEmpty()
                .WithMessage("'Etapas' obrigatório");

            RuleFor(p => p.Etapas)
                .Must(etapas => etapas.Count(e => e.Tipo == TipoEtapa.Inicio) == 1)
                .WithMessage("O processo deve ter exatamente uma etapa de início");

            RuleFor(p => p.Etapas)
                 .Must(etapas => etapas.Count(e => e.Tipo == TipoEtapa.Fim) >= 1)
                 .WithMessage("O processo deve ter ao menos uma etapa de fim");

            RuleFor(p => p.Etapas)
                .Must(etapas =>
                {
                    foreach (var etapa in etapas.Where(e => e.Tipo != TipoEtapa.Inicio))
                        if (!etapas.Any(e => e.EtapasReferenciadas.Contains(etapa.Identificador)))
                            return false;

                    return true;
                })
                .WithMessage("Existem etapas não referenciadas");

            RuleForEach(p => p.Etapas)
                .SetValidator(new ValidadorEtapa());
        }
    }
}
