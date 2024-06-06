using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class RegiaoMap : IEntityTypeConfiguration<Regiao>
{
    public void Configure(EntityTypeBuilder<Regiao> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(regiao => regiao.Nome)
            .IsRequired()
            .HasMaxLength(15)
            .IsUnicode(false);

        builder.HasIndex(regiao => regiao.Nome)
            .IsUnique();
    }
}