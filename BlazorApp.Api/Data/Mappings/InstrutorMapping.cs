using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class InstrutorMapping : IEntityTypeConfiguration<Instrutor>
    {
        public void Configure(EntityTypeBuilder<Instrutor> builder)
        {
            builder.ToTable("Instrutor");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Cpf)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14);

            builder.Property(x => x.Especializacao)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Registro)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.Telefone)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            builder.Property(x => x.Assinatura)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.DataCriacao);

            builder.Property(x => x.DataAlteracao);
        }
    }
}
