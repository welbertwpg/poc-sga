using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;

namespace Processos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadasController : ControllerBase
    {
        private readonly IRepositorioParadas repositorioParadas;
        private readonly IValidator<Parada> validadorParadas;

        public ParadasController(IRepositorioParadas repositorioParadas, IValidator<Parada> validadorParadas)
        {
            this.repositorioParadas = repositorioParadas;
            this.validadorParadas = validadorParadas;
        }

        [HttpPost]
        public void Post([FromBody]Parada parada)
        {
            validadorParadas.ValidateAndThrow(parada);
            repositorioParadas.Inserir(parada);
        }
    }
}
