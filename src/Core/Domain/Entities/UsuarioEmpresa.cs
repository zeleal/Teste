using Shared.Abstractions;

namespace Domain.Entities
{
    public class UsuarioEmpresa : BaseEntity
    {
        public UsuarioEmpresa(Guid usuarioId, Guid empresaId)
        {
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }

        public UsuarioEmpresa() { }

        public Guid UsuarioId { get; private init; }
        public Guid EmpresaId { get; private init; }

        //Relaçao do EF
        public Usuario Usuario { get; private init; }
        public Empresa Empresa { get; private init; }
    }
}