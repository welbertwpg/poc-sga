using ServidorMonitoramento.Models;

namespace ServidorMonitoramento.Interfaces
{
    public interface IClienteSensoresHub
    {
        void AtualizarResultadosSensores(ResultadoSensores resultadoSensores);
    }
}
