using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class CertificadoMapping : IEntityTypeConfiguration<Certificado>
    {
        public void Configure(EntityTypeBuilder<Certificado> builder)
        {
            builder.ToTable("Certificado");

            builder.HasKey(x => new {x.TreinamentoId, x.Codigo});

            builder.Property(x => x.Codigo)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(32);

            builder.Property(x => x.DataInicioCertificado);

            builder.Property(x => x.Situacao)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.DataCriacao);

            builder.Property(x => x.DataAlteracao);
        }
    }
}
