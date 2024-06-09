using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IEmpresaService : IAppService
    {
        Task<Result<IEnumerable<EmpresaDto>>> ObterTodosAsync();
    }
}