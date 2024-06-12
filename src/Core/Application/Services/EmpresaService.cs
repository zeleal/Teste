using Application.Interfaces;
using Application.Requests;
using Application.Requests.EmpresaRequests;
using Ardalis.Result;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;

namespace Application.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IMapper _mapper;
    private readonly IEmpresaRepository _repository;

    public EmpresaService(IMapper mapper, IEmpresaRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<EmpresaDto> AdicionarAsync(AdicionarEmpresaRequests request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.AdicionarAsync(_mapper.Map<Empresa>(request.Empresa));

        return request.Empresa;
    }

    public async Task<EmpresaDto> AtualizarAsync(AtualizarEmpresaRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.AtualizarAsync(_mapper.Map<Empresa>(request.Empresa));

        return Result.Success(request.Empresa);
    }

    public async Task<EmpresaDto> ExcluirAsync(ExcluirEmpresaRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.ExcluirAsync(request.Id);

        return new EmpresaDto();
    }

    public async Task<Result<IEnumerable<EmpresaDto>>> ObterTodosAsync()
    {
        var empresas = await _repository.ObterTodosAsync();
        return Result.Success(_mapper.Map<IEnumerable<EmpresaDto>>(empresas));
    }

    public async Task<Result<EmpresaDto>> ObterPorIdAsync(GetByIdRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        var empresa = await _repository.ObterPorIdAsync(request.Id);

        return Result.Success(_mapper.Map<EmpresaDto>(empresa));
    }
}