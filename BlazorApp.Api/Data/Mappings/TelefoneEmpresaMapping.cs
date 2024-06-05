using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data.Mappings
{
    public class TelefoneEmpresaMapping : IEntityTypeConfiguration<TelefoneEmpresa>
    {
        public void Configure(EntityTypeBuilder<TelefoneEmpresa> builder)
        {
            builder.ToTable("TelefoneEmpresa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroTelefone)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            builder.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("SMALLINT");
        }
    }
}
