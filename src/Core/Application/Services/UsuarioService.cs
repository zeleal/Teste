using Application.Interfaces;
using Application.Requests;
using Application.Requests.UsuarioRequests;
using Ardalis.Result;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;

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

        public async Task<UsuarioDto> AdicionarAsync(AdicionarRequest request)
        {
            await request.ValidateAsync();
            if (!request.ValidationResult.IsValid)
            {
                throw new ValidationException(request.ValidationResult.Errors);
            }

            await _repository.AdicionarAsync(_mapper.Map<Usuario>(request.Usuario));

            return request.Usuario;
        }

        public async Task<UsuarioDto> AtualizarAsync(AtualizarRequest request)
        {
            await request.ValidateAsync();
            if (!request.ValidationResult.IsValid)
            {
                throw new ValidationException(request.ValidationResult.Errors);
            }

            await _repository.AtualizarAsync(_mapper.Map<Usuario>(request.Usuario));

            return new UsuarioDto();
        }

        public async Task<UsuarioDto> ExcluirAsync(ExcluirRequest request)
        {
            await request.ValidateAsync();
            if (!request.ValidationResult.IsValid)
            {
                throw new ValidationException(request.ValidationResult.Errors);
            }

            await _repository.ExcluirAsync(request.Id);

            return new UsuarioDto();
        }

        public async Task<Result<IEnumerable<UsuarioDto>>> ObterTodosAsync()
        {
            var usuarios = await _repository.ObterTodosAsync();
            return Result.Success(_mapper.Map<IEnumerable<UsuarioDto>>(usuarios));
        }

        public async Task<Result<UsuarioDto>> ObterPorIdAsync(GetByIdRequest request)
        {
            await request.ValidateAsync();
            if (!request.ValidationResult.IsValid)
            {
                throw new ValidationException(request.ValidationResult.Errors);
            }

            var usuario = await _repository.ObterPorIdAsync(request.Id);

            return Result.Success(_mapper.Map<UsuarioDto>(usuario));
        }
    }
}
