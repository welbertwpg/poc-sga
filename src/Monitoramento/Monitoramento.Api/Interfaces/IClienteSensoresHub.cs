using Monitoramento.Dominio.Models;
using System.Threading.Tasks;

namespace ServidorMonitoramento.Interfaces
{
    public interface IClienteSensoresHub
    {
        Task AtualizarResultadosSensores(ResultadoSensores resultadoSensores);
    }
}
