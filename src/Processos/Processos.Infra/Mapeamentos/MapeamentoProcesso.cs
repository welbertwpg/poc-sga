using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processos.Dominio.Entidades;

namespace Processos.Infra.Mapeamentos
{
    public class MapeamentoProcesso : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.HasKey(p => p.Identificador);

            builder.Property(p => p.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany(p => p.Etapas)
                .WithOne(e => e.Processo);
        }
    }
}
