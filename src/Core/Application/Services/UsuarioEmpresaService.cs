using Application.Interfaces;
using Application.Requests.UsuarioEmpresaRequests;
using Ardalis.Result;
using AutoMapper;
using Domain.Dto;
using Domain.Repositories;
using FluentValidation;

namespace Application.Services;

public class UsuarioEmpresaService : IUsuarioEmpresaService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioEmpresaRepository _repository;

    public UsuarioEmpresaService(IMapper mapper, IUsuarioEmpresaRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<UsuarioEmpresaDto> AdicionarAsync(AdicionarUsuarioEmpresaRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.AdicionarAsync(request.UsuarioEmpresa);

        return new UsuarioEmpresaDto();
    }

    public async Task<UsuarioEmpresaDto> AtualizarAsync(AtualizarUsuarioEmpresaRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.AtualizarAsync(request.UsuarioEmpresa);

        return new UsuarioEmpresaDto();
    }

    public async Task<UsuarioEmpresaDto> ExcluirAsync(ExcluirUsuarioEmpresaRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.ExcluirAsync(request.UsuarioId,request.EmpresaId);

        return new UsuarioEmpresaDto();
    }

    public async Task<Result<IEnumerable<UsuarioEmpresaDto>>> ObterTodosAsync()
    {
        var usuarioEmpresas = await _repository.ObterTodosAsync();
        return Result.Success(_mapper.Map<IEnumerable<UsuarioEmpresaDto>>(usuarioEmpresas));
    }

    public async Task<Result<UsuarioEmpresaDto>> ObterPorIdAsync(ObterUsuarioEmpresaPorIdRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        var usuarioEmpresa = await _repository.ObterPorIdAsync(request.UsuarioId,request.EmpresaId);

        return Result.Success(_mapper.Map<UsuarioEmpresaDto>(usuarioEmpresa));
    }
}