using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories.Common;

namespace Infrastructure.Data.Repositories;

public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
{
    public CidadeRepository(SgpContext context) : base(context)
    {
    }

    public async Task<Cidade> ObterPorIbgeAsync(int ibge)
        => await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Include(c => c.Estado)
            .ThenInclude(e => e.Regiao)
            .FirstOrDefaultAsync(c => c.Ibge == ibge);

    public async Task<IEnumerable<Cidade>> ObterTodosPorUfAsync(string uf)
        => await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Include(c => c.Estado)
            .ThenInclude(e => e.Regiao)
            .Where(c => c.Estado.Uf == uf)
            .OrderBy(c => c.Nome)
            .ThenBy(c => c.Ibge)
            .ToListAsync();
}