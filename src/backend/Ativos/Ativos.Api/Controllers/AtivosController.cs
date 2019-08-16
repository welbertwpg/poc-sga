﻿using Ativos.Dominio.Interfaces;
using Ativos.Dominio.Entidades;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Ativos.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AtivosController : ControllerBase
    {
        private readonly IRepositorioAtivos repositorioAtivos;
        private readonly IRepositorioManutencoes repositorioManutencoes;
        private readonly IValidator<Ativo> validadorAtivos;
        private readonly IValidator<Manutencao> validadorManutencao;
        private readonly IServicoAquisicoes servicoAquisicoes;

        public AtivosController(IRepositorioAtivos repositorioAtivos,
            IRepositorioManutencoes repositorioManutencoes,
            IValidator<Ativo> validadorAtivos,
            IValidator<Manutencao> validadorManutencao,
            IServicoAquisicoes servicoAquisicoes)
        {
            this.repositorioAtivos = repositorioAtivos;
            this.repositorioManutencoes = repositorioManutencoes;
            this.validadorAtivos = validadorAtivos;
            this.validadorManutencao = validadorManutencao;
            this.servicoAquisicoes = servicoAquisicoes;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ativo>> Obter()
            => Ok(repositorioAtivos.Obter());

        [HttpGet("{id}")]
        public ActionResult<Ativo> Obter([FromRoute]string id)
            => Ok(repositorioAtivos.Obter(ObjectId.Parse(id)));

        [HttpPost]
        public void Inserir([FromBody]Ativo ativo)
        {
            validadorAtivos.ValidateAndThrow(ativo);
            repositorioAtivos.Inserir(ativo);
        }

        [HttpPost("{id}/manutencao")]
        public void InserirManutencao([FromRoute]string id, [FromBody]Manutencao manutencao)
        {
            validadorManutencao.ValidateAndThrow(manutencao);
            repositorioManutencoes.Inserir(ObjectId.Parse(id), manutencao);
        }

        [HttpPut("{id}")]
        public void Atualizar([FromBody]Ativo ativo)
        {
            validadorAtivos.ValidateAndThrow(ativo);
            repositorioAtivos.Atualizar(ativo);
        }

        [HttpPut("{id}/manutencao/{idManutencao}")]
        public void AtualizarManutencao([FromRoute]string id, [FromRoute]string idManutencao)
            => repositorioManutencoes.AtualizarStatus(ObjectId.Parse(id), ObjectId.Parse(idManutencao), true);

        [HttpDelete("{id}")]
        public void Deletar([FromRoute]string id)
            => repositorioAtivos.Deletar(ObjectId.Parse(id));

        [HttpPost("adquirir/{id}")]
        public void Adquirir([FromRoute]int id)
        {
            var ativo = servicoAquisicoes.AdquirirAtivo(id);
            validadorAtivos.ValidateAndThrow(ativo);
            repositorioAtivos.Inserir(ativo);
        }
    }
}