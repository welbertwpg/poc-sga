using AtivosApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativos.Dominio.Models
{
    public class CronogramaManutencao
    {
        [BsonId]
        public ObjectId Identificador { get; set; }
        public FrequenciaManutencao Frequencia { get; set; }
        public TipoAtivo TipoAtivo { get; set; }
        public int IntervaloHorasUso { get; set; }
    }
}
