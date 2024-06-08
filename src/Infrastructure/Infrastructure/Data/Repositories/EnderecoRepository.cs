using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SgpContext context) : base(context){}

        public async Task<Endereco> ObterEnderecoPorUsuarioAsync(int cpf)
            => await DbSet.AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(e => e.Usuario.Cpf == cpf);
    }
}