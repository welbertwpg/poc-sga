using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;

namespace Processos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemasController : ControllerBase
    {
        private readonly IRepositorioProblemas repositorioProblemas;
        private readonly IValidator<Problema> validadorProblema;

        public ProblemasController(IRepositorioProblemas repositorioProblemas, IValidator<Problema> validadorProblema)
        {
            this.repositorioProblemas = repositorioProblemas;
            this.validadorProblema = validadorProblema;
        }

        [HttpPost]
        public void Post([FromBody]Problema problema)
        {
            validadorProblema.ValidateAndThrow(problema);
            repositorioProblemas.Inserir(problema);
        }
    }
}
