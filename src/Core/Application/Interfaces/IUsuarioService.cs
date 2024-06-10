using Application.Requests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IUsuarioService : IAppService
    {
        Task<Result<UsuarioDto>> ObterPorIdAsync(Guid id);
        Task<Result<UsuarioDto>> ExcluirAsync(GetByIdRequest request);
        Task<Result<IEnumerable<UsuarioDto>>> ObterTodosAsync(UsuarioRequest request);
        Task<Result<UsuarioDto>> AdicionarAsync();
        Task<Result<UsuarioDto>> AtualizarAsync();
    }
}