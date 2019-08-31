using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ativos.Dominio.Entidades
{
    public class CronogramaManutencao
    {
        [BsonId]
        public ObjectId Identificador { get; set; }
        public FrequenciaManutencao Frequencia { get; set; }
        public TipoAtivo TipoAtivo { get; set; }
        public int? IntervaloHorasUso { get; set; }

        public CronogramaManutencao()
            => Identificador = ObjectId.GenerateNewId();

        public bool VerificarManutencaoNecessaria(DateTime ultimaManutencao, int horasUso)
        {
            int diferencaDias = (DateTime.Now - ultimaManutencao).Days;
            switch (Frequencia)
            {
                case FrequenciaManutencao.Diaria:
                    return diferencaDias >= 1;
                case FrequenciaManutencao.Semanal:
                    return diferencaDias >= 7;
                case FrequenciaManutencao.Mensal:
                    return diferencaDias >= 30;
                case FrequenciaManutencao.Anual:
                    return diferencaDias >= 365;
                case FrequenciaManutencao.Intervalo:
                    return horasUso >= IntervaloHorasUso.Value;
                default:
                    return false;
            }
        }

        public DateTime ObterDataProximaManutencao()
        {
            switch (Frequencia)
            {
                case FrequenciaManutencao.Diaria:
                    return DateTime.Now.AddDays(1);
                case FrequenciaManutencao.Semanal:
                    return DateTime.Now.AddDays(7);
                case FrequenciaManutencao.Mensal:
                    return DateTime.Now.AddMonths(1);
                case FrequenciaManutencao.Anual:
                    return DateTime.Now.AddYears(1);
                case FrequenciaManutencao.Intervalo:
                    return DateTime.Now.AddHours(IntervaloHorasUso.Value);
                default:
                    return DateTime.Now;
            }
        }
    }
}
