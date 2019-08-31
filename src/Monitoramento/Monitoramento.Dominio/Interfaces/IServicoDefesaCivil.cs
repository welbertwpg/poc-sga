using Monitoramento.Dominio.Entidades;

namespace Monitoramento.Dominio.Interfaces
{
    public interface IServicoDefesaCivil
    {
        void SolicitarReconhecimentoDesastre(ResultadoSensores resultado);
    }
}
