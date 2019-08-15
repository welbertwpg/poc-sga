using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Processos.Api.Filtros
{
    public class FiltroExcecaoValidacao : ExceptionFilterAttribute
    {
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
        }
    }
}
