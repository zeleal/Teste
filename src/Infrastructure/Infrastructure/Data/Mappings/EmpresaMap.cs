using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class EmpresaMap : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(empresa => empresa.NomeFantasia)
            .IsRequired()
            .HasMaxLength(150)
            .IsUnicode(false);

        builder.Property(empresa => empresa.RazaoSocial)
            .IsRequired()
            .HasMaxLength(150)
            .IsUnicode(false);

        builder.Property(empresa => empresa.Cnpj)
            .IsRequired();

        builder.HasIndex(empresa => empresa.Cnpj)
            .IsUnique();
    }
}