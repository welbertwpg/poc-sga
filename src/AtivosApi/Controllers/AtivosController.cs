using AtivosApi.Database.Interfaces;
using AtivosApi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;

namespace AtivosApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AtivosController : ControllerBase
    {
        private readonly IRepositorioAtivos repositorioAtivos;
        private readonly IRepositorioManutencoes repositorioManutencoes;
        private readonly IValidator<Ativo> validadorAtivos;
        private readonly IValidator<Manutencao> validadorManutencao;

        public AtivosController(IRepositorioAtivos repositorioAtivos,
            IRepositorioManutencoes repositorioManutencoes,
            IValidator<Ativo> validadorAtivos,
            IValidator<Manutencao> validadorManutencao)
        {
            this.repositorioAtivos = repositorioAtivos;
            this.repositorioManutencoes = repositorioManutencoes;
            this.validadorAtivos = validadorAtivos;
            this.validadorManutencao = validadorManutencao;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ativo>> Get()
            => Ok(repositorioAtivos.Obter());

        [HttpGet("{id}")]
        public ActionResult<Ativo> Get([FromRoute]string id)
            => Ok(repositorioAtivos.Obter(ObjectId.Parse(id)));

        [HttpPost]
        public void Post([FromBody]Ativo ativo)
        {
            validadorAtivos.ValidateAndThrow(ativo);
            repositorioAtivos.Inserir(ativo);
        }

        [HttpPost("{id}/manutencao")]
        public void Post([FromRoute]string id, [FromBody]Manutencao manutencao)
        {
            validadorManutencao.ValidateAndThrow(manutencao);
            repositorioManutencoes.Inserir(ObjectId.Parse(id), manutencao);
        }

        [HttpPut("{id}/manutencao/{idManutencao}")]
        public void Put([FromRoute]string id, [FromRoute]string idManutencao)
            => repositorioManutencoes.AtualizarStatus(ObjectId.Parse(id), ObjectId.Parse(idManutencao), true);

        [HttpPut("{id}")]
        public void Put([FromBody]Ativo ativo)
        {
            validadorAtivos.ValidateAndThrow(ativo);
            repositorioAtivos.Atualizar(ativo);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]string id)
            => repositorioAtivos.Deletar(ObjectId.Parse(id));
    }
}
