using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processos.Dominio.Entidades;

namespace Processos.Infra.Mapeamentos
{
    public class MapeamentoParada : IEntityTypeConfiguration<Parada>
    {
        public void Configure(EntityTypeBuilder<Parada> builder)
        {
            builder.HasKey(p => p.Identificador);

            builder.Property(p => p.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Turno)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(p => p.Data)
                .IsRequired();
        }
    }
}
