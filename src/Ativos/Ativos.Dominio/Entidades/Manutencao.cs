using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ativos.Dominio.Entidades
{
    public class Manutencao
    {
        public Manutencao()
        {
            Identificador = ObjectId.GenerateNewId();
            Realizada = false;
        }

        [BsonId]
        public ObjectId Identificador { get; set; }
        public DateTime DataHora { get; set; }
        public DateTime? DataHoraRealizada { get; set; }
        public TipoManutencao Tipo { get; set; }
        public bool Realizada { get; set; }
    }
}
