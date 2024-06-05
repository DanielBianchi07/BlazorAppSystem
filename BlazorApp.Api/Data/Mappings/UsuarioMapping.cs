using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Nome)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Senha)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.IsAdmin)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.DataCriacao);
        }
    }
}
