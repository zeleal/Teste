using Shared.Abstractions;

namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, DateTime dataNascimento, string nomePai, string nomeMae, int cpf, string email, string senha)
        {
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

        public Endereco Endereco { get; private init; }
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