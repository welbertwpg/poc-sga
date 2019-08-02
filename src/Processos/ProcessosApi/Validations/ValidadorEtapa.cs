﻿using FluentValidation;
using ProcessosApi.Models;
using System.Linq;

namespace ProcessosApi.Validations
{
    public class ValidadorEtapa : AbstractValidator<Etapa>
    {
        public ValidadorEtapa()
        {
            RuleFor(e => e.EtapasReferenciadas)
                .Must(er => er.Any())
                .When(e => e.Tipo == TipoEtapa.Inicio)
                .WithMessage("A etapa de inicio deve apontar para ao menos uma etapa");

            RuleFor(e => e.EtapasReferenciadas)
                .Must(er => !er.Any())
                .When(e => e.Tipo == TipoEtapa.Fim)
                .WithMessage("As etapas de fim não devem apontar para outra etapa");

            RuleFor(e => e.EtapasReferenciadas)
                .Must(er => er.Any())
                .When(e => e.Tipo == TipoEtapa.Acao)
                .WithMessage("As etapas de ação devem apontar para ao menos uma outra etapa");

            RuleFor(e => e.EtapasReferenciadas)
                .Must(er => er.Count() >= 2)
                .When(e => e.Tipo == TipoEtapa.Decisao)
                .WithMessage("As etapas de decisão devem apontar para ao menos duas outras etapas");

            RuleFor(e => e)
                .Must(e => !e.EtapasReferenciadas.Contains(e.Id))
                .WithMessage("Uma etapa não pode se auto referenciar");
        }
    }
}