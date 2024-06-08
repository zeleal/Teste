using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Domain.Entities;
using Infrastructure.Extensions;
using Shared.AppSettings;

namespace Infrastructure.Data.Context;

public sealed class SgpContext : DbContext
{
    private readonly string _collation;

    public SgpContext(DbContextOptions<SgpContext> dbOptions) : base(dbOptions)
        => ChangeTracker.LazyLoadingEnabled = false;

    public SgpContext(IOptions<ConnectionStrings> options, DbContextOptions<SgpContext> dbOptions) : this(dbOptions)
        => _collation = options.Value.Collation;

    public DbSet<Cidade> Cidades => Set<Cidade>();
    public DbSet<Estado> Estados => Set<Estado>();
    public DbSet<Regiao> Regioes => Set<Regiao>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<UsuarioEmpresa> UsuarioEmpresas => Set<UsuarioEmpresa>();
    public DbSet<Endereco> Enderecos => Set<Endereco>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrWhiteSpace(_collation))
            modelBuilder.UseCollation(_collation);

        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
            .RemoveCascadeDeleteConvention();
    }
}