﻿using AtivosApi.Database.Interfaces;
using AtivosApi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AtivosApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AtivosController : ControllerBase
    {
        private readonly IRepositorioAtivos repositorioAtivos;
        private readonly IValidator<Ativo> validadorAtivos;

        public AtivosController(IRepositorioAtivos repositorioAtivos, IValidator<Ativo> validadorAtivos)
        {
            this.repositorioAtivos = repositorioAtivos;
            this.validadorAtivos = validadorAtivos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ativo>> Get()
            => Ok(repositorioAtivos.Obter());

        [HttpGet("{id}")]
        public ActionResult<Ativo> Get(Guid id)
            => Ok(repositorioAtivos.Obter(id));

        [HttpPost]
        public void Post([FromBody] Ativo ativo)
        {
            validadorAtivos.ValidateAndThrow(ativo);
            repositorioAtivos.Inserir(ativo);
        }

        [HttpPost("{id}/manutencao")]
        public void Post(Guid id, 
            [FromBody] Manutencao manutencao, 
            [FromServices]IValidator<Manutencao> validadorManutencao)
        {
            validadorManutencao.ValidateAndThrow(manutencao);
            repositorioAtivos.InserirManutencao(id, manutencao);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Ativo ativo)
        {
            validadorAtivos.ValidateAndThrow(ativo);
            repositorioAtivos.Atualizar(ativo);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
            => repositorioAtivos.Deletar(id);
    }
}
