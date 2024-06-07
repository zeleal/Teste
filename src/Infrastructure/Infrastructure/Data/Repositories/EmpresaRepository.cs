using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(SgpContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Empresa>> ObterTodosAsync()
            => await DbSet
                .AsNoTrackingWithIdentityResolution()
                .OrderBy(e => e.Cnpj)
                .ToListAsync();
    }
}