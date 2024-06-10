using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ConfigureBaseEntity();

            builder.HasKey(em => em.Id);

            builder.Property(em => em.RazaoSocial)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(em => em.NomeFantasia)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(em => em.CNPJ)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.HasIndex(em => em.CNPJ)
                .IsUnique();
        }
    }
}
