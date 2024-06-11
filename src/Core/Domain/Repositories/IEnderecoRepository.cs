using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IEnderecoRepository : IRepository
    {
        Task<Endereco> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Endereco>> ObterTodosAsync();
        Task AdicionarAsync(Endereco endereco);
        Task AtualizarAsync(Endereco endereco);
        Task ExcluirAsync(Guid id);
    }
}