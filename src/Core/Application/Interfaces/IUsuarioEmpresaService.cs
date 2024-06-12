using Application.Requests.UsuarioEmpresaRequests;
using Ardalis.Result;
using Domain.Dto;
using Domain.Entities;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IUsuarioEmpresaService : IAppService
    {
        //Task<Result<UsuarioEmpresaDto>> ObterPorIdAsync(ObterUsuarioEmpresaPorIdRequest request);
        //Task<UsuarioEmpresaDto> ExcluirAsync(ExcluirUsuarioEmpresaRequest request);
        Task<Result<IEnumerable<UsuarioEmpresa>>> ObterTodosAsync();
        Task<UsuarioEmpresaDto> AdicionarAsync(AdicionarUsuarioEmpresaRequest request);
        Task<UsuarioEmpresaDto> AtualizarAsync(AtualizarUsuarioEmpresaRequest request);
        Task<Result<IEnumerable<EmpresaDto>>> ObterEmpresaPorUsuarioAsync(ObterEmpresaPorUsuarioRequest request);
        Task<Result<IEnumerable<UsuarioDto>>> ObterUsuarioPorEmpresaAsync(ObterUsuarioPorEmpresaRequest request);
    }
}