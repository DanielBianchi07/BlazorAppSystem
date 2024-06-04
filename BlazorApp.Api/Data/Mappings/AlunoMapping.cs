using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Cpf)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14);

            builder.Property(x => x.Rg)
                .HasColumnType("VARCHAR")
                .HasMaxLength(12);

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Telefone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            builder.Property(x => x.Assinatura)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.DataCriacao);

            builder.Property(x => x.DataAlteracao);
        }
    }
}
