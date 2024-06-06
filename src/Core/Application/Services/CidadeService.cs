using Domain.Dto;
using AutoMapper;
using Ardalis.Result;
using Domain.Repositories;
using Application.Interfaces;
using Ardalis.Result.FluentValidation;
using Application.Requests.CidadeRequests;

namespace Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly IMapper _mapper;
        private readonly ICidadeRepository _repository;

        public CidadeService(IMapper mapper, ICidadeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<CidadeDto>> ObterPorIbgeAsync(ObterPorIbgeRequest request)
        {
            await request.ValidateAsync();
            if (!request.IsValid)
                return Result.Invalid(request.ValidationResult.AsErrors());

            var cidade = await _repository.ObterPorIbgeAsync(request.Ibge);
            if (cidade == null)
                return Result.NotFound($"Nenhuma cidade encontrada pelo IBGE: {request.Ibge}");

            return Result.Success(_mapper.Map<CidadeDto>(cidade));
        }

        public async Task<Result<IEnumerable<CidadeDto>>> ObterTodosPorUfAsync(ObterTodosPorUfRequest request)
        {
            await request.ValidateAsync();
            if (!request.IsValid)
                return Result.Invalid(request.ValidationResult.AsErrors());

            var cidades = await _repository.ObterTodosPorUfAsync(request.Uf.ToUpperInvariant());
            if (!cidades.Any())
                return Result.NotFound($"Nenhuma cidade encontrada pelo UF: {request.Uf}");

            return Result.Success(_mapper.Map<IEnumerable<CidadeDto>>(cidades));
        }
    }
}
