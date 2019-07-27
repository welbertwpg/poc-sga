using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace AtivosApi.Models
{
    public class Ativo
    {
        public Ativo()
        {
            Identificador = ObjectId.GenerateNewId();
            Manutencoes = new List<Manutencao>();
        }

        [BsonId]
        public ObjectId Identificador { get; set; }
        public string Nome { get; set; }
        public string Patrimonio { get; set; }
        public TipoAtivo Tipo { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Observacoes { get; set; }
        public int MediaHorasUsoDiariamente { get; set; }

        public IList<Manutencao> Manutencoes { get; set; }
    }
}
