using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class AlternativaMapping : IEntityTypeConfiguration<Alternativa>
    {
        public void Configure(EntityTypeBuilder<Alternativa> builder)
        {
            builder.ToTable("Alternativa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Conteudo)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Resposta)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("SMALLINT");
        }
    }
}
