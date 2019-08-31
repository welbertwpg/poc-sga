using Microsoft.AspNetCore.Mvc;
using Monitoramento.Dominio.Interfaces;
using Monitoramento.Dominio.Entidades;
using Microsoft.Extensions.Options;

namespace Monitoramento.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private readonly ISensores sensores;
        private readonly Limites limites;

        public SensoresController(ISensores sensores, IOptions<Limites> limites)
        {
            this.sensores = sensores;
            this.limites = limites.Value;
        }

        [HttpGet("limites")]
        public ActionResult<Limites> ObterLimites()
            => limites;

        [HttpGet("sensores")]
        public ActionResult<ResultadoSensores> ObterResultados()
            => sensores.Obter();
    }
}
