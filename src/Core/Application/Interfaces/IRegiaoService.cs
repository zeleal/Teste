using System.Collections.Generic;
using Domain.Dto;
using Ardalis.Result;
using Shared.Abstractions;

namespace Application.Interfaces;

public interface IRegiaoService : IAppService
{
    Task<Result<IEnumerable<RegiaoDto>>> ObterTodosAsync();
}