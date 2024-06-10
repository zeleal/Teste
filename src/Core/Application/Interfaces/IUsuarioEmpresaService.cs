using Application.Requests;
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
        Task<Result<UsuarioEmpresaDto>> ObterPorIdAsync(GetByIdRequest request, GetByIdRequest request2);
        Task<Result<UsuarioEmpresaDto>> ExcluirAsync(GetByIdRequest request, GetByIdRequest request2);
        Task<Result<IEnumerable<UsuarioEmpresaDto>>> ObterTodosAsync();
        Task<Result<UsuarioEmpresaDto>> AdicionarAsync();
        Task<Result<UsuarioEmpresaDto>> AtualizarAsync();
    }
}