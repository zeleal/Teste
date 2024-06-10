﻿using Application.Requests;
using Application.Requests.EmpresaRequests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;

namespace Application.Interfaces
{
    public interface IEmpresaService : IAppService
    {
        Task<Result<EmpresaDto>> ObterPorIdAsync(GetByIdRequest request);
        Task<EmpresaDto> ExcluirAsync(ExcluirEmpresaRequest request);
        Task<Result<IEnumerable<EmpresaDto>>> ObterTodosAsync();
        Task<EmpresaDto> AdicionarAsync(AdicionarEmpresaRequests request);
        Task<EmpresaDto> AtualizarAsync(AtualizarEmpresaRequest request);
    }
}