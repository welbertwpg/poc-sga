using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processos.Dominio.Entidades;

namespace Processos.Infra.Mapeamentos
{
    class MapeamentoEtapa : IEntityTypeConfiguration<Etapa>
    {
        public void Configure(EntityTypeBuilder<Etapa> builder)
        {
            builder.HasKey(e => e.Identificador);

            builder.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.X)
                .IsRequired();

            builder.Property(e => e.Y)
                .IsRequired();

            builder.Property(e => e.Tipo)
                .HasConversion<int>()
                .IsRequired();

            builder.HasMany(e => e.EtapasSaida)
                .WithOne(e => e.EtapaEntrada);

            builder.HasMany(e => e.Problemas)
                .WithOne(p => p.Etapa);

            builder.HasMany(e => e.Paradas)
                .WithOne(p => p.Etapa);
        }
    }
}
