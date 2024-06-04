using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Logo)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.CargaHorariaInicial)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.CargaHorariaPeriodico)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.Validade)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.DataCriacao);

            builder.Property(x => x.DataAlteracao);
        }
    }
}
