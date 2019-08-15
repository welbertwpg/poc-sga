using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Monitoramento.Api.Interfaces;
using Monitoramento.Dominio.Entidades;
using Monitoramento.Dominio.Interfaces;
using Monitoramento.Infra.AMQP;

namespace Monitoramento.Api.Hubs
{
    public class SensoresHub : Hub<IClienteSensoresHub>
    {
        private readonly IServicoDefesaCivil servicoDefesaCivil;
        private readonly IConexaoFila conexaoFila;
        private readonly Limites limites;

        public SensoresHub(IServicoDefesaCivil servicoDefesaCivil, IConexaoFila conexaoFila, IOptions<Limites> limites)
        {
            this.servicoDefesaCivil = servicoDefesaCivil;
            this.conexaoFila = conexaoFila;
            this.limites = limites.Value;
        }

        public void AtualizarResultadosSensores(ResultadoSensores resultadoSensores)
        {
            if (!resultadoSensores.Validar(limites))
            {
                conexaoFila.EnviarMensagem(new Alerta { Criticidade = CriticidadeAlerta.Media, Mensagem = "Foi detectada uma anormalidade nos sensores da barragem." });
                servicoDefesaCivil.SolicitarReconhecimentoDesastre(resultadoSensores);
            }

            Clients.All.AtualizarResultadosSensores(resultadoSensores);
        }
    }
}
