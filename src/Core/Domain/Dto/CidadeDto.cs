
namespace Domain.Dto
{
    public class CidadeDto
    {
        public Guid Id { get; private init; }
        public Guid EstadoId { get; private init; }
        public string Nome { get; private init; }
        public int Ibge { get; private init; }
    }
}
