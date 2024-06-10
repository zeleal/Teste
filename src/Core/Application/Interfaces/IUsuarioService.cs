using Application.Requests;
using Application.Requests.EnderecoRequests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IUsuarioService : IAppService
    {
        Task<Result<UsuarioDto>> ObterPorIdAsync(GetByIdRequest request);
        Task<Result<UsuarioDto>> ExcluirAsync(ExcluirRequest request);
        Task<Result<IEnumerable<UsuarioDto>>> ObterTodosAsync();
        Task<Result<UsuarioDto>> AdicionarAsync(AdicionarRequest request);
        Task<Result<UsuarioDto>> AtualizarAsync(AtualizarRequest request);
    }
}