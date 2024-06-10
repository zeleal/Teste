using Application.Interfaces;
using Application.Requests;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using Azure.Core;
using Domain.Dto;
using Domain.Entities;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _repository;

        public UsuarioService(IMapper mapper, IUsuarioService repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<UsuarioDto>> AdicionarAsync()
        {
            var usuario = _mapper.Map<Usuario>(request);
            await _repository.AddAsync(usuario);
            return Result.Success();
        }

        public async Task<Result<UsuarioDto>> AtualizarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<UsuarioDto>> ExcluirAsync(GetByIdRequest request)
        {
            await request.ValidateAsync();
            if (!request.IsValid)
                return Result.Invalid(request.ValidationResult.AsErrors());

            var usuario = await _repository.ExcluirAsync(request);
            if (usuario == null)
                return Result.NotFound($"Nenhum Usuario para este Id: {request.Id}");

            return Result.Success(_mapper.Map<UsuarioDto>(usuario));
        }

        public async Task<Result<UsuarioDto>> ObterPorIdAsync(Guid id)
        {
            var usuario = await _repository.ObterPorIdAsync(id);

            if (usuario == null)
                return Result.NotFound("Usuario não encontrado");

            return Result.Success(_mapper.Map<UsuarioDto>(usuario));
        }

        public async Task<Result<IEnumerable<UsuarioDto>>> ObterTodosAsync()
        {
            var usuarios = await _repository.ObterTodosAsync();
            return Result.Success(_mapper.Map<IEnumerable<UsuarioDto>>(usuarios));
        }
    }
}
