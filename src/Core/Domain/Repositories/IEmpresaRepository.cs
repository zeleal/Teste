using Domain.Entities;
using Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEmpresaRepository : IRepository
    {
        Task<Empresa> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Empresa>> ObterTodosAsync();
        Task AdicionarAsync(Empresa empresa);
        Task AtualizarAsync(Empresa empresa);
        Task ExcluirAsync(Guid id);
    }
}
