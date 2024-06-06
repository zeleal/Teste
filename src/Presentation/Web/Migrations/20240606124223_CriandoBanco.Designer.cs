﻿// <auto-generated />
using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(SgpContext))]
    [Migration("20240606124223_CriandoBanco")]
    partial class CriandoBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Latin1_General_CI_AI")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ibge")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("Ibge")
                        .IsUnique();

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)");

                    b.Property<Guid>("RegiaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("RegiaoId");

                    b.HasIndex("Uf")
                        .IsUnique();

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Domain.Entities.Regiao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Regioes");
                });

            modelBuilder.Entity("Domain.Entities.Cidade", b =>
                {
                    b.HasOne("Domain.Entities.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.HasOne("Domain.Entities.Regiao", "Regiao")
                        .WithMany("Estados")
                        .HasForeignKey("RegiaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Regiao");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Navigation("Cidades");
                });

            modelBuilder.Entity("Domain.Entities.Regiao", b =>
                {
                    b.Navigation("Estados");
                });
#pragma warning restore 612, 618
        }
    }
}
