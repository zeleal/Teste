using Application.Interfaces;
using Ardalis.Result;
using AutoMapper;
using Domain.Dto;
using Domain.Repositories;

namespace Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _repository;

        public EmpresaService(IMapper mapper, IEmpresaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<IEnumerable<EmpresaDto>>> ObterTodosAsync()
        {
            var empresas = await _repository.ObterTodosAsync();
            return Result.Success(_mapper.Map<IEnumerable<EmpresaDto>>(empresas));
        }
    }
}