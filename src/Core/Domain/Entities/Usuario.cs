using Shared.Abstractions;

namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(Guid enderecoId, string nome, DateTime dataNascimento, string nomePai, string nomeMae, int cpf, string email, string senha)
        {
            EnderecoId = enderecoId;
            Nome = nome;
            DataNascimento = dataNascimento;
            NomePai = nomePai;
            NomeMae = nomeMae;
            Email = email;
            Senha = senha;
        }

        public Usuario()
        {
        }

        public Guid EnderecoId { get; set; }
        public string Nome { get; private init; }
        public DateTime DataNascimento { get; private init; }
        public string NomePai { get; private init; }
        public string NomeMae { get; private init; }
        public int Cpf { get; private init; }
        public string Email { get; private init; }
        public string Senha { get; private init; }

        //Relaçao do EF
        public IReadOnlyList<UsuarioEmpresa> UsuarioEmpresas { get; private init; }
    }
}