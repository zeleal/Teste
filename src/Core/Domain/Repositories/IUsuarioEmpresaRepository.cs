using Domain.Entities;
using Shared.Abstractions;

namespace Domain.Repositories
{
    public interface IUsuarioEmpresaRepository : IRepository
    {
        Task<IEnumerable<Empresa>> ObterEmpresaPorUsuario(int cpf);
        Task<IEnumerable<Usuario>> ObterUsuarioPorEmpresa (string cnpj);
    }
}