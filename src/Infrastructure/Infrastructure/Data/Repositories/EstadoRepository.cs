using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Common;

namespace Infrastructure.Data.Repositories;

public class EstadoRepository : RepositoryBase<Estado>, IEstadoRepository
{
    public EstadoRepository(SgpContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Estado>> ObterTodosAsync()
        => await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Include(e => e.Regiao)
            .OrderBy(e => e.Nome)
            .ToListAsync();

    public async Task<IEnumerable<Estado>> ObterTodosPorRegiaoAsync(string regiao)
        => await DbSet
            .AsNoTrackingWithIdentityResolution()
            .Include(e => e.Regiao)
            .Where(e => e.Regiao.Nome == regiao)
            .OrderBy(e => e.Nome)
            .ToListAsync();
}