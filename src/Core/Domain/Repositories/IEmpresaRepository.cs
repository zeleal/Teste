using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IEmpresaRepository : IRepository
    {
        Task<IEnumerable<Empresa>> ObterTodosAsync();
    }
}