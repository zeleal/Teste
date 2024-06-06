using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface ICidadeRepository : IRepository
    {
        Task<Cidade> ObterPorIbgeAsync(int ibge);
        Task<IEnumerable<Cidade>> ObterTodosPorUfAsync(string uf);
    }
}
