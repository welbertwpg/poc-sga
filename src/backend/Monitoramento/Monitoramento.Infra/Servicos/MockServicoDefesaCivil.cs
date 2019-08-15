using Monitoramento.Dominio.Entidades;
using Monitoramento.Dominio.Interfaces;

namespace Monitoramento.Infra.Servicos
{
    public class MockServicoDefesaCivil : IServicoDefesaCivil
    {
        public void SolicitarReconhecimentoDesastre(ResultadoSensores resultado)
        {
            //Realiza chamada ao sistema da defesa civil informando os dados obtidos no monitoramento
        }
    }
}
