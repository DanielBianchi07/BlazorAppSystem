using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class ProvaMapping : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            builder.ToTable("Prova");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataCriacao);

            builder.Property(x => x.DataAlteracao);

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("SMALLINT");
        }
    }
}
