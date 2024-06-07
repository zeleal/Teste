namespace Domain.Dto
{
    public class UsuarioDto
    {
        public Guid Id { get; private init; }
        public Guid EnderecoId { get; private init; }
        public string Nome { get; private init; }
        public DateTime DataNascimento { get; private init; }
        public string NomePai { get; private init; }
        public string NomeMae { get; private init; }
        public int Cpf { get; private init; }
        public string Email { get; private init; }
        public string Senha { get; private init; }
    }
}