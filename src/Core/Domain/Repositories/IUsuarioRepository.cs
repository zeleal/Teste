using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IUsuarioRepository : IRepository
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
    }
}
