namespace Domain.Dto
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; private init; }
        public Guid CidadeId { get; private init; }
        public string Rua { get; private init; }
        public string Bairro { get; private init; }
        public string Cep { get; private init; }
        public string Complemento { get; private init; }
        public int Numero { get; private init; }
    }
}