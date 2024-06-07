using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(endereco => endereco.CidadeId)
            .IsRequired();

        builder.Property(c => c.Cep)
            .IsRequired()
            .HasColumnType("varchar(8)");

        builder.Property(c => c.Bairro)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(c => c.Numero)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(c => c.Complemento)
            .HasColumnType("varchar(250)");

        // 1 : N => Cidade : Enderecos
        builder.HasOne(endereco => endereco.Cidade)
            .WithMany(cidade => cidade.Enderecos)
            .HasForeignKey(endereco => endereco.CidadeId);
    }
}