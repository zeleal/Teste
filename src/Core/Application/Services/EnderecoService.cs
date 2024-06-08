using Application.Interfaces;
using Application.Requests.EnderecoRequests;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoService _repository;

        public EnderecoService(IMapper mapper, IEnderecoService repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<EnderecoDto>> ObterEnderecoPorUsuarioAsync(ObterEnderecoPorUsuarioRequests request)
        {
            await request.ValidateAsync();
            if (!request.IsValid)
                return Result.Invalid(request.ValidationResult.AsErrors());

            var endereco = await _repository.ObterEnderecoPorUsuarioAsync(request);

            if (endereco == null)
                return Result.NotFound($"Nenhum Endereço foi encontrado para o CPF: {request.Cpf}");

            return Result.Success(_mapper.Map<EnderecoDto>(endereco));
        }
    }
}