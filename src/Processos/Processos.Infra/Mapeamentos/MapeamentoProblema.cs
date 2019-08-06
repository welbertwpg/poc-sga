using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processos.Dominio.Entidades;

namespace Processos.Infra.Mapeamentos
{
    public class MapeamentoProblema : IEntityTypeConfiguration<Problema>
    {
        public void Configure(EntityTypeBuilder<Problema> builder)
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
