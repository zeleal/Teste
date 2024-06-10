﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsuarioEmpresaRepository
    {
        Task<UsuarioEmpresa> ObterPorIdAsync(Guid usuarioId, Guid empresaId);
        Task<IEnumerable<UsuarioEmpresa>> ObterTodosAsync();
        Task AdicionarAsync(UsuarioEmpresa usuarioEmpresa);
        Task AtualizarAsync(UsuarioEmpresa usuarioEmpresa);
        Task ExcluirAsync(Guid usuarioId, Guid empresaId);
    }
}