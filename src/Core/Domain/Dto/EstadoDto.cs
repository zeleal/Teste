
namespace Domain.Dto
{
    public class EstadoDto
    {
        public Guid Id { get; private init; }
        public Guid RegiaoId { get; private init; }
        public string Nome { get; private init; }
        public string Uf { get; private init; }
    }
}
