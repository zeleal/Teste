using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class UsuarioEmpresaMap : IEntityTypeConfiguration<UsuarioEmpresa>
{
    public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(usuarioEmpresa => usuarioEmpresa.EmpresaId)
            .IsRequired();

        builder.Property(usuarioEmpresa => usuarioEmpresa.UsuarioId)
            .IsRequired();

        // 1 : N => UsuarioEmpresas : Empresas
        builder.HasOne(usuarioEmpresa => usuarioEmpresa.Empresas)
            .WithMany(empresa => empresa.UsuarioEmpresas)
            .HasForeignKey(usuarioEmpresa => usuarioEmpresa.EmpresaId);

        // 1 : N => UsuarioEmpresas : Usuarios
        builder.HasOne(usuarioEmpresa => usuarioEmpresa.Usuarios)
            .WithMany(empresa => empresa.UsuarioEmpresas)
            .HasForeignKey(usuarioEmpresa => usuarioEmpresa.UsuarioId);
    }
}