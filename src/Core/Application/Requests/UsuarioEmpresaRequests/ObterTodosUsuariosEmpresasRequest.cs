using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests;

public class ObterTodosUsuariosEmpresasRequest : BaseRequestWithValidation
{
    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<ObterTodosUsuariosEmpresasRequestValidator>(this);
}