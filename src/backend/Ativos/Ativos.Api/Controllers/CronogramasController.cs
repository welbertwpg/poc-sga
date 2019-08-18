using Ativos.Dominio.Interfaces;
using Ativos.Dominio.Entidades;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Ativos.Api.Controllers
{
    [Route("api/manutencao/cronogramas")]
    [ApiController]
    public class CronogramasController : Controller
    {
        private readonly IRepositorioCronogramas repositorioCronogramas;
        private readonly IValidator<CronogramaManutencao> validadorCronogramas;

        public CronogramasController(IRepositorioCronogramas repositorioCronogramas,
            IValidator<CronogramaManutencao> validadorCronogramas)
        {
            this.repositorioCronogramas = repositorioCronogramas;
            this.validadorCronogramas = validadorCronogramas;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CronogramaManutencao>> Obter()
            => Ok(repositorioCronogramas.Obter());

        [HttpPost]
        public IActionResult Inserir([FromBody]CronogramaManutencao cronograma)
        {
            validadorCronogramas.ValidateAndThrow(cronograma);
            repositorioCronogramas.Inserir(cronograma);
            return Ok(cronograma.Identificador);
        }

        [HttpDelete("{id}")]
        public void Deletar([FromRoute]string id)
            => repositorioCronogramas.Deletar(ObjectId.Parse(id));
    }
}