using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    internal class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        private readonly SgpContext _context;

        public EmpresaRepository(SgpContext context) : base(context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Empresa empresa)
        {
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var empresa = await ObterPorIdAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Empresa> ObterPorIdAsync(Guid id)
        {
            return await _context.Empresas.FindAsync(id);
        }

        public async Task<IEnumerable<Empresa>> ObterTodosAsync()
        {
            return await _context.Empresas.ToListAsync();
        }
    }
}