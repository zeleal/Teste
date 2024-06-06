using Domain.Dto;
using Ardalis.Result;
using Shared.Abstractions;
using Application.Requests.CidadeRequests;

namespace Application.Interfaces
{
    public interface ICidadeService : IAppService
    {
        Task<Result<CidadeDto>> ObterPorIbgeAsync(ObterPorIbgeRequest request);
        Task<Result<IEnumerable<CidadeDto>>> ObterTodosPorUfAsync(ObterTodosPorUfRequest request);
    }
}
