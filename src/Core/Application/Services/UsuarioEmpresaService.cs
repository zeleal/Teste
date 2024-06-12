using Application.Interfaces;
using Application.Requests.UsuarioEmpresaRequests;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
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

        await _repository.AdicionarAsync(_mapper.Map<UsuarioEmpresa>(request.UsuarioEmpresa));

        return request.UsuarioEmpresa;
    }

    public async Task<UsuarioEmpresaDto> AtualizarAsync(AtualizarUsuarioEmpresaRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.AtualizarAsync(_mapper.Map<UsuarioEmpresa>(request.UsuarioEmpresa));

        return new UsuarioEmpresaDto();
    }

    //public async Task<UsuarioEmpresaDto> ExcluirAsync(ExcluirUsuarioEmpresaRequest request)
    //{
    //    await request.ValidateAsync();
    //    if (!request.ValidationResult.IsValid)
    //    {
    //        throw new ValidationException(request.ValidationResult.Errors);
    //    }

    //    await _repository.ExcluirAsync(request.UsuarioId,request.EmpresaId);

    //    return new UsuarioEmpresaDto();
    //}

    public async Task<Result<IEnumerable<UsuarioEmpresa>>> ObterTodosAsync()
    {
        var usuarioEmpresas = await _repository.ObterTodosAsync();
        return Result.Success(_mapper.Map<IEnumerable<UsuarioEmpresa>>(usuarioEmpresas));
    }

    public async Task<Result<IEnumerable<EmpresaDto>>> ObterEmpresaPorUsuarioAsync(ObterEmpresaPorUsuarioRequest request)
    {
        await request.ValidateAsync();
        if (!request.IsValid)
            return Result.Invalid(request.ValidationResult.AsErrors());

        var empresaPorUsuario = await _repository.ObterEmpresaPorUsuarioAsync(request.Cpf);
        if (empresaPorUsuario == null)
            return Result.NotFound($"Nenhuma Empresa para o seguinte CPF: {request.Cpf}");

        return Result.Success(_mapper.Map<IEnumerable<EmpresaDto>>(empresaPorUsuario));
    }

    public async Task<Result<IEnumerable<UsuarioDto>>> ObterUsuarioPorEmpresaAsync(ObterUsuarioPorEmpresaRequest request)
    {
        await request.ValidateAsync();
        if (!request.IsValid)
            return Result.Invalid(request.ValidationResult.AsErrors());

        var usuarioPorEmpresa = await _repository.ObterUsuarioPorEmpresaAsync(request.Cnpj);

        if (usuarioPorEmpresa == null)
            return Result.NotFound($"Nenhum Usuario para o seguinte Cnpj: {request.Cnpj}");

        return Result.Success(_mapper.Map<IEnumerable<UsuarioDto>>(usuarioPorEmpresa));
    }
}