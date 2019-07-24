using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AtivosApi.Models
{
    public class Manutencao
    {
        public Manutencao()
        {
            Identificador = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId Identificador { get; set; }
        public Ativo Ativo { get; set; }
        public DateTime Data { get; set; }
        public TipoManutencao TipoManutencao { get; set; }
    }
}
