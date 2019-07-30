using Monitoramento.Dominio.Models;

namespace Monitoramento.Dominio.Interfaces
{
    public interface IClienteSensoresHub
    {
        void AtualizarResultadosSensores(ResultadoSensores resultadoSensores);
    }
}
