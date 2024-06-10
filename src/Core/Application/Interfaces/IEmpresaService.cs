using Application.Requests;
using Application.Requests.CidadeRequests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IEmpresaService : IAppService
    {
        Task<Result<EmpresaDto>> ObterPorIdAsync(GetByIdRequest request);
        Task<Result<EmpresaDto>> ExcluirAsync(GetByIdRequest request);
        Task<Result<IEnumerable<EmpresaDto>>> ObterTodosAsync();
        Task<Result<EmpresaDto>> AdicionarAsync();
        Task<Result<EmpresaDto>> AtualizarAsync();
    }
}