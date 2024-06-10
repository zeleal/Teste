using Application.Requests;
using Application.Requests.UsuarioEmpresaRequests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsuarioEmpresaService : IAppService
    {
        Task<Result<UsuarioEmpresaDto>> ObterPorIdAsync(ObterUsuarioEmpresaPorIdRequest request);
        Task<Result<UsuarioEmpresaDto>> ExcluirAsync(ExcluirUsuarioEmpresaRequest request);
        Task<Result<IEnumerable<UsuarioEmpresaDto>>> ObterTodosAsync();
        Task<Result<UsuarioEmpresaDto>> AdicionarAsync(AdicionarUsuarioEmpresaRequest request);
        Task<Result<UsuarioEmpresaDto>> AtualizarAsync(AtualizarUsuarioEmpresaRequest request);
    }
}