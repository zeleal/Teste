using Application.Interfaces;
using Application.Requests;
using Application.Requests.EnderecoRequests;
using Ardalis.Result;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;

namespace Application.Services;

public class EnderecoService : IEnderecoService
{
    private readonly IMapper _mapper;
    private readonly IEnderecoRepository _repository;

    public EnderecoService(IMapper mapper, IEnderecoRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<EnderecoDto> AdicionarAsync(AdicionarRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.AdicionarAsync(_mapper.Map<Endereco>(request.Endereco));

        return new EnderecoDto();
    }

    public async Task<EnderecoDto> AtualizarAsync(AtualizarRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.AtualizarAsync(_mapper.Map<Endereco>(request.Endereco));

        return new EnderecoDto();
    }

    public async Task<EnderecoDto> ExcluirAsync(ExcluirRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        await _repository.ExcluirAsync(request.Id);

        return new EnderecoDto();
    }

    public async Task<Result<IEnumerable<EnderecoDto>>> ObterTodosAsync()
    {
        var enderecos = await _repository.ObterTodosAsync();
        return Result.Success(_mapper.Map<IEnumerable<EnderecoDto>>(enderecos));
    }

    public async Task<Result<EnderecoDto>> ObterPorIdAsync(GetByIdRequest request)
    {
        await request.ValidateAsync();
        if (!request.ValidationResult.IsValid)
        {
            throw new ValidationException(request.ValidationResult.Errors);
        }

        var endereco = await _repository.ObterPorIdAsync(request.Id);

        return Result.Success(_mapper.Map<EnderecoDto>(endereco));
    }
}