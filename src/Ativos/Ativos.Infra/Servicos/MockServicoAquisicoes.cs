using Ativos.Dominio.Interfaces;
using Ativos.Dominio.Entidades;
using System;

namespace Ativos.Infra.Servicos
{
    public class MockServicoAquisicoes : IServicoAquisicoes
    {
        //Também deve ser prevista uma integração deste módulo com o sistema de aquisições, não contemplado no escopo deste trabalho.
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
