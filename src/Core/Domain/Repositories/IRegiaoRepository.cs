﻿using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IRegiaoRepository : IRepository
    {
        Task<IEnumerable<Regiao>> ObterTodosAsync();
    }
}
