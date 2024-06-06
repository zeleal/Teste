using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dto;
using Ardalis.Result;
using Shared.Abstractions;
using Application.Requests.EstadoRequests;

namespace Application.Interfaces;

public interface IEstadoService : IAppService
{
    Task<Result<IEnumerable<EstadoDto>>> ObterTodosAsync();
    Task<Result<IEnumerable<EstadoDto>>> ObterTodosPorRegiaoAsync(ObterTodosPorRegiaoRequest request);
}