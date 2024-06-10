using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEnderecoRepository
    {
        Task<Endereco> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Endereco>> ObterTodosAsync();
        Task AdicionarAsync(Endereco endereco);
        Task AtualizarAsync(Endereco endereco);
        Task ExcluirAsync(Guid id);
    }
}