using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class ConteudoProgramaticoMapping : IEntityTypeConfiguration<ConteudoProgramatico>
    {
        public void Configure(EntityTypeBuilder<ConteudoProgramatico> builder)
        {
            builder.ToTable("ConteudoProgramatico");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Assunto)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.CargaHoraria)
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