using Microsoft.AspNetCore.SignalR;
using Monitoramento.Dominio.Interfaces;
using Monitoramento.Dominio.Models;
using Monitoramento.Infra.AMQP;

namespace ServidorMonitoramento.Hubs
{
    public class SensoresHub : Hub<IClienteSensoresHub>
    {
        private readonly IRepositorioNormasAmbientais repositorioNormasAmbientais;
        private readonly IConexaoFila conexaoFila;

        public SensoresHub(IRepositorioNormasAmbientais repositorioNormasAmbientais, IConexaoFila conexaoFila)
        {
            this.repositorioNormasAmbientais = repositorioNormasAmbientais;
            this.conexaoFila = conexaoFila;
        }

        public void AtualizarResultadosSensores(ResultadoSensores resultadoSensores)
        {
            var normas = repositorioNormasAmbientais.Obter();

            if (resultadoSensores.Piezometro.Nivel >= normas.NivelMaximoPermitido || resultadoSensores.Piezometro.Pressao >= normas.PressaoMaximaPermitida)
                conexaoFila.EnviarMensagem(new Alerta { Criticidade = CriticidadeAlerta.Media, Mensagem = "Foi detectada uma anormalidade nos sensores da barragem." });

            Clients.All.AtualizarResultadosSensores(resultadoSensores);
        }
    }
}
