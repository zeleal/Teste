namespace Domain.Dto
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public Guid EstadoId { get; private init; }
        public string Rua { get; private init; }
        public string Bairro { get; private init; }
        public string Complemento { get; private init; }
        public string Cep { get; private init; }
    }
}