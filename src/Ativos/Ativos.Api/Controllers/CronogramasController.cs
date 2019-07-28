using Ativos.Dominio.Interfaces;
using Ativos.Dominio.Models;
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
        public void Inserir([FromBody]CronogramaManutencao cronograma)
        {
            validadorCronogramas.ValidateAndThrow(cronograma);
            repositorioCronogramas.Inserir(cronograma);
        }

        [HttpDelete("{id}")]
        public void Deletar([FromRoute]string id)
            => repositorioCronogramas.Deletar(ObjectId.Parse(id));
    }
}