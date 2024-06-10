﻿using Application.Requests;
using Ardalis.Result;
using Domain.Dto;
using Shared.Abstractions;


namespace Application.Interfaces
{
    public interface IEnderecoService : IAppService
    {
        Task<Result<EnderecoDto>> ObterPorIdAsync(GetByIdRequest request);
        Task<Result<EnderecoDto>> ExcluirAsync(GetByIdRequest request);
        Task<Result<IEnumerable<EnderecoDto>>> ObterTodosAsync();
        Task<Result<EnderecoDto>> AdicionarAsync();
        Task<Result<EnderecoDto>> AtualizarAsync();
    }
}