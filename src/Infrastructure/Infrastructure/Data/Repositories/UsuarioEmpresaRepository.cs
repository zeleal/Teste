using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class UsuarioEmpresaRepository : RepositoryBase<UsuarioEmpresa>, IUsuarioEmpresaRepository
{
    public UsuarioEmpresaRepository(SgpContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Empresa>> ObterEmpresaPorUsuario(int cpf)
        => await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(ue => ue.Usuarios.Cpf == cpf)
            .Select(ue => ue.Empresas)
            .OrderBy(e=>e.Cnpj)
            .ToListAsync();

    public async Task<IEnumerable<Usuario>> ObterUsuarioPorEmpresa(string cnpj)
        => await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Where(ue => ue.Empresas.Cnpj == cnpj)
            .Select(ue => ue.Usuarios)
            .OrderBy(u => u.Cpf)
            .ToListAsync();
}