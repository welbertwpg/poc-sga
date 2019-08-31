using Monitoramento.Dominio.Entidades;
using System.Threading.Tasks;

namespace Monitoramento.Api.Interfaces
{
    public interface IClienteSensoresHub
    {
        Task AtualizarResultadosSensores(ResultadoSensores resultadoSensores);
    }
}
