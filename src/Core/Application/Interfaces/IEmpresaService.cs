using Application.Requests;
using Application.Requests.EmpresaRequests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IEmpresaService : IAppService
    {
        Task<Result<EmpresaDto>> ObterPorIdAsync(GetByIdRequest request);
        Task<Result<EmpresaDto>> ExcluirAsync(ExcluirEmpresaRequest request);
        Task<Result<IEnumerable<EmpresaDto>>> ObterTodosAsync();
        Task<Result<EmpresaDto>> AdicionarAsync(AdicionarEmpresaRequests request);
        Task<Result<EmpresaDto>> AtualizarAsync(AtualizarEmpresaRequest request);
    }
}