using Application.Requests.EnderecoRequests;
using Ardalis.Result;
using Domain.Dto;
using Domain.Entities;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IEnderecoService : IAppService
    {
        Task<Result<EnderecoDto>> ObterEnderecoPorUsuarioAsync(ObterEnderecoPorUsuarioRequests request);
    }
}