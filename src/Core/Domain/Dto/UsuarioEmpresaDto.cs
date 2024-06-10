namespace Domain.Dto
{
    public class UsuarioEmpresaDto
    {
        public Guid Id { get; private init; }
        public Guid UsuarioId { get; private init; }
        public Guid EmpresaId { get; private init; }
    }
}