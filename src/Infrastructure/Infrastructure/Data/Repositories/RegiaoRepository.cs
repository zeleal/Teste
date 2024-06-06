using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories.Common;

namespace Infrastructure.Data.Repositories;

public class RegiaoRepository : RepositoryBase<Regiao>, IRegiaoRepository
{
    public RegiaoRepository(SgpContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Regiao>> ObterTodosAsync()
        => await DbSet.AsNoTracking().OrderBy(r => r.Nome).ToListAsync();
}