using System;

namespace AtivosApi.Models
{
    public class Ativo
    {
        public Ativo()
            => Identificador = Guid.NewGuid();

        public Guid Identificador { get; set; }
        public string Nome { get; set; }
        public string Patrimonio { get; set; }
        public TipoAtivo Tipo { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Observacoes { get; set; }
        public int MediaHorasUsoDiariamente { get; set; }
    }
}
