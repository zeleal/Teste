using Application.Requests.UsuarioEmpresaRequests;
using Ardalis.Result;
using Domain.Dto;
using Domain.Entities;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IUsuarioEmpresaService : IAppService
    {
        Task<Result<EmpresaDto>> ObterEmpresaPorUsuarioAsync(ObterEmpresaPorUsuarioRequest request);
        Task<Result<UsuarioDto>> ObterUsuarioPorEmpresaAsync(ObterUsuarioPorEmpresaRequest request);
    }
}