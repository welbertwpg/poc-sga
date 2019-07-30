﻿using Microsoft.AspNetCore.Mvc;
using ServidorMonitoramento.Interfaces;
using ServidorMonitoramento.Models;

namespace ServidorMonitoramento.Controllers
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