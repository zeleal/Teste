using Application.Interfaces;
using Application.Requests.UsuarioEmpresaRequests;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioEmpresaService : IUsuarioEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioEmpresaRepository _repository;

        public UsuarioEmpresaService(IMapper mapper, IUsuarioEmpresaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<EmpresaDto>> ObterEmpresaPorUsuarioAsync(ObterEmpresaPorUsuarioRequest request)
        {
            await request.ValidateAsync();
            if (!request.IsValid)
                return Result.Invalid(request.ValidationResult.AsErrors());

            var empresaPorUsuario = await _repository.ObterEmpresaPorUsuarioAsync(request.Cpf);
            if (empresaPorUsuario == null)
                return Result.NotFound($"Nenhuma Empresa para o seguinte CPF: {request.Cpf}");

            return Result.Success(_mapper.Map<EmpresaDto>(empresaPorUsuario));
        }

        public async Task<Result<UsuarioDto>> ObterUsuarioPorEmpresaAsync(ObterUsuarioPorEmpresaRequest request)
        {
            await request.ValidateAsync();
            if (!request.IsValid)
                return Result.Invalid(request.ValidationResult.AsErrors());

            var usuarioPorEmpresa = await _repository.ObterUsuarioPorEmpresaAsync(request.Cnpj);
            if (usuarioPorEmpresa == null)
                return Result.NotFound($"Nenhum Usuario para o seguinte Cnpj: {request.Cnpj}");

            return Result.Success(_mapper.Map<UsuarioDto>(usuarioPorEmpresa));
        }
    }
}
