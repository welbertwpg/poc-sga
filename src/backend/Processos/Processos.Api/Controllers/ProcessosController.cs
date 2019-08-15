using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Processos.Dominio.Entidades;
using Processos.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Processos.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProcessosController : ControllerBase
    {
        private readonly IRepositorioProcessos repositorioProcessos;
        private readonly IValidator<Processo> validadorProcessos;

        public ProcessosController(IRepositorioProcessos repositorioProcessos, IValidator<Processo> validadorProcessos)
        {
            this.repositorioProcessos = repositorioProcessos;
            this.validadorProcessos = validadorProcessos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Processo>> Get()
            => Ok(repositorioProcessos.Obter());

        [HttpGet("{id}")]
        public ActionResult<Processo> Get(Guid id)
            => repositorioProcessos.Obter(id);

        [HttpPut]
        public void Put([FromBody]Processo processo)
        {
            validadorProcessos.ValidateAndThrow(processo);
            repositorioProcessos.InserirOuAtualizar(processo);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
            => repositorioProcessos.Deletar(id);
    }
}
