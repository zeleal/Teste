﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SgpContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
            => await DbSet
                .AsNoTrackingWithIdentityResolution()
                .Include(e => e.Endereco)
                .OrderBy(e => e.Nome)
                .ToListAsync();
    }
}