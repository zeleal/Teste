namespace Domain.Dto
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }

        public string Nome { get; private init; }
        public string Cpf { get; private init; }
        public string NomeDaMae { get; private init; }
        public string NomeDoPai { get; private init; }
        public string Email { get; private init; }
        public DateTime DataNascimento { get; private init; }
    }
}