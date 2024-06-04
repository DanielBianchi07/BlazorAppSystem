using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace BlazorApp.Api.Data.Mappings
{
    public class TreinamentoMapping : IEntityTypeConfiguration<Treinamento>
    {
        public void Configure(EntityTypeBuilder<Treinamento> builder)
        {
            builder.ToTable("Treinamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.Situacao)
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
