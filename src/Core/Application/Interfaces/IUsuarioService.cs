using Application.Requests.CidadeRequests;
using Application.Requests.UsuarioRequests;
using Ardalis.Result;
using Domain.Dto;
using Domain.Entities;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IUsuarioService : IAppService
    {
        Task<Result<IEnumerable<UsuarioDto>>> ObterTodosAsync();
        Task<Result<UsuarioDto>> ObterUsuarioEnderecoAsync(ObterUsuarioEnderecoRequest request);
    }
}