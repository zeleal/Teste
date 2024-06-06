using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IEstadoRepository : IRepository
    {
        Task<IEnumerable<Estado>> ObterTodosAsync();
        Task<IEnumerable<Estado>> ObterTodosPorRegiaoAsync(string regiao);
    }
}
