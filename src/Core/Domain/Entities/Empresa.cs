using Shared.Abstractions;

namespace Domain.Entities
{
    public class Empresa : BaseEntity
    {
        public Empresa(string cnpj, string razaoSocial, string nomeFantasia)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        public Empresa()
        {
        }

        public string Cnpj { get; private init; }
        public string RazaoSocial { get; private init; }
        public string NomeFantasia { get; private init; }

        //Relaçao do EF
        public IReadOnlyList<UsuarioEmpresa> UsuarioEmpresas { get; private init; }
    }
}
