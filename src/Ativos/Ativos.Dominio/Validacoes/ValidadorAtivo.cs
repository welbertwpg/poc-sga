using Ativos.Dominio.Entidades;
using FluentValidation;

namespace Ativos.Dominio.Validacoes
{
    public class ValidadorAtivo : AbstractValidator<Ativo>
    {
        public ValidadorAtivo()
        {
            RuleFor(m => m.Identificador)
                .NotEmpty()
                .WithMessage("'Identificador' obrigatório");

            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("'Nome' obrigatório");

            RuleFor(a => a.DataAquisicao)
                .NotEmpty()
                .WithMessage("'DataAquisicao' obrigatório");

            RuleFor(a => a.MediaHorasUsoDiariamente)
                .NotEmpty()
                .WithMessage("'MediaHorasUsoDiariamente' obrigatório");

            RuleFor(a => a.MediaHorasUsoDiariamente)
                .GreaterThan(0)
                .WithMessage("'MediaHorasUsoDiariamente' deve ser um número positivo");

            RuleFor(a => a.Tipo)
                .NotEmpty()
                .WithMessage("'Tipo' obrigatório");

            RuleFor(a => a.Patrimonio)
                .NotEmpty()
                .WithMessage("'Patrimonio' obrigatório");
        }
    }
}
