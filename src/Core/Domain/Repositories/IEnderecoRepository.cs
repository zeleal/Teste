using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IEnderecoRepository : IRepository
    {
        Task<Endereco> ObterPorUsuarioAsync(Guid usuarioId);
    }
}