using Application.Requests;
using Application.Requests.UsuarioRequests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IUsuarioService : IAppService
    {
        Task<Result<UsuarioDto>> ObterPorIdAsync(GetByIdRequest request);
        Task<UsuarioDto> ExcluirAsync(ExcluirRequest request);
        Task<Result<IEnumerable<UsuarioDto>>> ObterTodosAsync();
        Task<UsuarioDto> AdicionarAsync(AdicionarRequest request);
        Task<UsuarioDto> AtualizarAsync(AtualizarRequest request);
    }
}