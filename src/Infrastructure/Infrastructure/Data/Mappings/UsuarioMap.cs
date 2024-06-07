using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(usuario => usuario.EnderecoId)
            .IsRequired();

        builder.Property(usuario => usuario.Cpf)
            .IsRequired();

        builder.HasIndex(usuario => usuario.Cpf)
            .IsUnique();

        // 1 : 1 => Usuarios : Enderecos
        builder.HasOne(usuario => usuario.Endereco)
            .WithOne(endereco => endereco.Usuario);
    }
}