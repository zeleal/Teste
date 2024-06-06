using Domain.Dto;
using AutoMapper;
using Ardalis.Result;
using Domain.Repositories;
using Application.Interfaces;
using Ardalis.Result.FluentValidation;
using Application.Requests.EstadoRequests;

namespace Application.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _repository;

        public EstadoService(IMapper mapper, IEstadoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<IEnumerable<EstadoDto>>> ObterTodosAsync()
        {
            var estados = await _repository.ObterTodosAsync();
            return Result.Success(_mapper.Map<IEnumerable<EstadoDto>>(estados));
        }

        public async Task<Result<IEnumerable<EstadoDto>>> ObterTodosPorRegiaoAsync(ObterTodosPorRegiaoRequest request)
        {
            await request.ValidateAsync();
            if (!request.IsValid)
                return Result.Invalid(request.ValidationResult.AsErrors());

            var estados = await _repository.ObterTodosPorRegiaoAsync(request.Regiao);
            if (!estados.Any())
                return Result.NotFound($"Nenhum estado encontrado pela região: {request.Regiao}");

            return Result.Success(_mapper.Map<IEnumerable<EstadoDto>>(estados));
        }
    }
}
