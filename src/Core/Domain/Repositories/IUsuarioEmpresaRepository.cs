using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IUsuarioEmpresaRepository : IRepository
    {
        Task<IEnumerable<Empresa>> ObterEmpresaPorUsuarioAsync(int cpf);
        Task<IEnumerable<Usuario>> ObterUsuarioPorEmpresaAsync(string cnpj);
    }
}