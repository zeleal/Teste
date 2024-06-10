﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UsuarioEmpresaRepository : RepositoryBase<UsuarioEmpresa>, IUsuarioEmpresaRepository
    {
        private readonly SgpContext _context;

        public UsuarioEmpresaRepository(SgpContext context) : base(context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(UsuarioEmpresa usuarioEmpresa)
        {
            await _context.UsuarioEmpresas.AddAsync(usuarioEmpresa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(UsuarioEmpresa usuarioEmpresa)
        {
            _context.Entry(usuarioEmpresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid usuarioId, Guid empresaId)
        {
            var usuarioEmpresa = await ObterPorIdAsync(usuarioId, empresaId);
            if (usuarioEmpresa != null)
            {
                _context.UsuarioEmpresas.Remove(usuarioEmpresa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UsuarioEmpresa> ObterPorIdAsync(Guid usuarioId, Guid empresaId)
        {
            return await _context.UsuarioEmpresas
                       .Include(ue => ue.Usuario)
                       .Include(ue => ue.Empresa)
                       .FirstOrDefaultAsync(ue => ue.UsuarioId == usuarioId && ue.EmpresaId == empresaId);
        }

        public async Task<IEnumerable<UsuarioEmpresa>> ObterTodosAsync()
        {
            return await _context.UsuarioEmpresas
                .Include(ue => ue.Usuario)
                .Include(ue => ue.Empresa)
                .ToListAsync();
        }
    }
}