using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Infrastructure.Extensions;

namespace Infrastructure.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ConfigureBaseEntity();

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(u => u.NomeDaMae)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(u => u.NomeDoPai)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(u=>u.DataNascimento)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(u => u.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.HasIndex(u => u.Cpf)
                .IsUnique();

            builder.HasOne(u => u.Endereco)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Endereco>(e => e.UsuarioId);

            builder.ToTable("Usuarios");
        }
    }
}
