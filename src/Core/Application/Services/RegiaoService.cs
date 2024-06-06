using Application.Interfaces;
using Ardalis.Result;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Dto;

namespace Application.Services
{
    public class RegiaoService : IRegiaoService
    {
        private readonly IMapper _mapper;
        private readonly IRegiaoRepository _repository;

        public RegiaoService(IMapper mapper, IRegiaoRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<RegiaoDto>>> ObterTodosAsync()
        {
            var regioes = await _repository.ObterTodosAsync();
            return Result.Success(_mapper.Map<IEnumerable<RegiaoDto>>(regioes));
        }
    }
}
