﻿using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IEnderecoRepository : IRepository
    {
        Task<Endereco> ObterEnderecoPorUsuarioAsync(int cpf);
    }
}