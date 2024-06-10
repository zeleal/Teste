using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests;

public class ObterUsuarioEmpresaPorIdRequest : BaseRequestWithValidation
{
    public ObterUsuarioEmpresaPorIdRequest(Guid usuarioId, Guid empresaId)
    {
        UsuarioId = usuarioId;
        EmpresaId = empresaId;
    }

    public Guid UsuarioId { get; }
    public Guid EmpresaId { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<ObterUsuarioEmpresaPorIdRequestValidator>(this);
}