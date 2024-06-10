using Application.Requests.UsuarioEmpresaRequests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IUsuarioEmpresaService : IAppService
    {
        Task<Result<UsuarioEmpresaDto>> ObterPorIdAsync(ObterUsuarioEmpresaPorIdRequest request);
        Task<UsuarioEmpresaDto> ExcluirAsync(ExcluirUsuarioEmpresaRequest request);
        Task<Result<IEnumerable<UsuarioEmpresaDto>>> ObterTodosAsync();
        Task<UsuarioEmpresaDto> AdicionarAsync(AdicionarUsuarioEmpresaRequest request);
        Task<UsuarioEmpresaDto> AtualizarAsync(AtualizarUsuarioEmpresaRequest request);
        Task<Result<EmpresaDto>> ObterEmpresaPorUsuarioAsync(ObterEmpresaPorUsuarioRequest request);
        Task<Result<UsuarioDto>> ObterUsuarioPorEmpresaAsync(ObterUsuarioPorEmpresaRequest request);
    }
}