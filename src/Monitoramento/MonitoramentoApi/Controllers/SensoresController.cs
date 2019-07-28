using Microsoft.AspNetCore.Mvc;
using MonitoramentoApi.Interfaces;
using MonitoramentoApi.Models;

namespace MonitoramentoApi.Controllers
{
    [Route("api/sensores")]
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private readonly ISensores sensores;

        public SensoresController(ISensores sensores)
            => this.sensores = sensores;

        [HttpGet]
        public ActionResult<ResultadoSensores> Obter()
            => sensores.Obter();
    }
}
