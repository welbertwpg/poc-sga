using Ativos.Dominio.Interfaces;
using Ativos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Ativos.Infra.Servicos
{
    //Também deve ser prevista uma integração deste módulo com o sistema de aquisições, não contemplado no escopo deste trabalho.
    public class MockServicoAquisicoes : IServicoAquisicoes
    {
        public IEnumerable<Adquirivel> ObterAdquiriveis()
            => new List<Adquirivel>
            {
                new Adquirivel
                {
                    Identificador = 1,
                    Nome= "Caminhão de mineiração",
                    Descricao =  "Suporta até 363 toneladas de minério."
                }
            };

        public Ativo AdquirirAtivo(int id)
            => new Ativo
            {
                Nome = "Caminhão de mineiração",
                Patrimonio = "VL123456",
                DataAquisicao = DateTime.Now,
                MediaHorasUsoDiariamente = 4,
                Tipo = TipoAtivo.Maquina,
                Observacoes = "Equipamento com número de série 543JJHGF8546HG, suporta até 363 toneladas de minério."
            };
    }
}
