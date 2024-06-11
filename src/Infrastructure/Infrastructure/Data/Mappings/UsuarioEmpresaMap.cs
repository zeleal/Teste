using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class UsuarioEmpresaMap : IEntityTypeConfiguration<UsuarioEmpresa>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.ConfigureBaseEntity();

            //builder.HasKey(ue => new { ue.UsuarioId, ue.EmpresaId });
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            //builder.HasOne(ue => ue.Usuario)
            //    .WithMany(u => u.UsuarioEmpresas)
            //    .HasForeignKey(ue => ue.UsuarioId);

            //builder.HasOne(ue => ue.Empresa)
            //    .WithMany(em => em.UsuarioEmpresas)
            //    .HasForeignKey(ue => ue.EmpresaId);

            builder.ToTable("UsuarioEmpresas");

        }
    }
}