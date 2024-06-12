using Application.Requests;
using Application.Requests.EnderecoRequests;
using Ardalis.Result;
using Domain.Dto;
using Domain.Entities;
using Shared.Abstractions;


namespace Application.Interfaces
{
    public interface IEnderecoService : IAppService
    {
        Task<Result<EnderecoDto>> ObterPorIdAsync(GetByIdRequest request);
        Task<EnderecoDto> ExcluirAsync(ExcluirRequest request);
        Task<Result<IEnumerable<Endereco>>> ObterTodosAsync();
        Task<EnderecoDto> AdicionarAsync(AdicionarRequest request);
        Task<EnderecoDto> AtualizarAsync(AtualizarRequest request);
    }
}