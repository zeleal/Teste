using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests;

public class ExcluirUsuarioEmpresaRequest : BaseRequestWithValidation
{
    public ExcluirUsuarioEmpresaRequest(Guid usuarioId, Guid empresaId)
    {
        UsuarioId = usuarioId;
        EmpresaId = empresaId;
    }

    public Guid UsuarioId { get; }
    public Guid EmpresaId { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<ExcluirUsuarioEmpresaRequestValidator>(this);
}