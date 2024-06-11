using Application.Interfaces;
using Application.Requests.UsuarioRequests;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IMapper mapper, IUsuarioRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<UsuarioDto>> ObterUsuarioEnderecoAsync(ObterUsuarioEnderecoRequest request)
        {
            await request.ValidateAsync();
            if (!request.IsValid)
                return Result.Invalid(request.ValidationResult.AsErrors());

            var endereco = await _repository.ObterUsuarioEnderecoAsync(request.Id);

            if (endereco == null)
                return Result.NotFound($"Nenhuma endereço encontrado para este usuario.");

            return Result.Success(_mapper.Map<UsuarioDto>(endereco));
        }

        public async Task<Result<IEnumerable<UsuarioDto>>> ObterTodosAsync()
        {
            var usuarios = await _repository.ObterTodosAsync();
            return Result.Success(_mapper.Map<IEnumerable<UsuarioDto>>(usuarios));
        }
    }
}