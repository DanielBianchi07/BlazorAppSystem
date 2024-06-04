using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class ListaPresencaMapping : IEntityTypeConfiguration<ListaPresenca>
    {
        public void Configure(EntityTypeBuilder<ListaPresenca> builder)
        {
            builder.ToTable("ListaPresenca");

            builder.HasKey(x => x.TreinamentoId);

            builder.Property(x => x.DataCriacao);

            builder.Property(x => x.DataAlteracao);

            builder.Property(x => x.Situacao)
                .IsRequired(true)
                .HasColumnType("SMALLINT");


            builder.Property(x => x.Codigo)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(32);
        }
    }
}
