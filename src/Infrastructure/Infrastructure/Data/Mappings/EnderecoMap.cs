using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Extensions;

namespace Infrastructure.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ConfigureBaseEntity();

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.CidadeId)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Rua)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Complemento)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Bairro)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.HasOne(e => e.Cidade)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.CidadeId);

            builder.ToTable("Enderecos");
        }
    }
}
