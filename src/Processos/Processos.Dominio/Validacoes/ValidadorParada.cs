﻿using FluentValidation;
using Processos.Dominio.Entidades;

namespace Processos.Dominio.Validacoes
{
    public class ValidadorParada : AbstractValidator<Parada>
    {
        public ValidadorParada()
        {
            RuleFor(p => p.Identificador)
                .NotEmpty()
                .WithMessage("'Identificador' obrigatório");

            RuleFor(p => p.IdentificadorProcesso)
                .NotEmpty()
                .WithMessage("'IdentificadorProcesso' obrigatório");

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
