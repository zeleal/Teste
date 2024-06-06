using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class EstadoMap : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(estado => estado.RegiaoId)
            .IsRequired();

        builder.Property(estado => estado.Nome)
            .IsRequired()
            .HasMaxLength(75)
            .IsUnicode(false);

        builder.Property(estado => estado.Uf)
            .IsRequired()
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsFixedLength();

        builder.HasIndex(estado => estado.Uf)
            .IsUnique();

        builder.HasOne(estado => estado.Regiao)
            .WithMany(regiao => regiao.Estados)
            .HasForeignKey(estado => estado.RegiaoId);
    }
}