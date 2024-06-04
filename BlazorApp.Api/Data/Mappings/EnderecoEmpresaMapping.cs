using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class EnderecoEmpresaMapping : IEntityTypeConfiguration<EnderecoEmpresa>
    {
        public void Configure(EntityTypeBuilder<EnderecoEmpresa> builder)
        {
            builder.ToTable("EnderecoEmpresa");

            builder.HasKey(x => x.EmpresaId);

            builder.Property(x => x.CEP)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(9);

            builder.Property(x => x.Estado)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(48);

            builder.Property(x => x.Cidade)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(48);

            builder.Property(x => x.Bairro)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.NomeRua)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Numero)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(5);

            builder.Property(x => x.Complemento)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("SMALLINT");
        }
    }
}
