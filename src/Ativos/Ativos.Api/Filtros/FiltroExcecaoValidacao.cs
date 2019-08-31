using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Ativos.Api.Filtros
{
    public class FiltroExcecaoValidacao : ExceptionFilterAttribute
    {
        private readonly ILogger logger;

        public FiltroExcecaoValidacao(ILogger logger)
            => this.logger = logger;

        public override void OnException(ExceptionContext contexto)
        {
            if (contexto.Exception is ValidationException)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Erros:");
                foreach (var erro in ((ValidationException)contexto.Exception).Errors)
                    stringBuilder.AppendLine($"- {erro.ErrorMessage}");
                contexto.Result = new ObjectResult(stringBuilder.ToString()) { StatusCode = 400 };
            }

            logger.Error(contexto.Exception, "Erro de validação");
        }
    }
}
