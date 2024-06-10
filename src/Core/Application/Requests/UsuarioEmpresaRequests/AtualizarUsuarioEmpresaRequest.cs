using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests;

public class AtualizarUsuarioEmpresaRequest : BaseRequestWithValidation
{
    public AtualizarUsuarioEmpresaRequest(UsuarioEmpresa usuarioEmpresa) => UsuarioEmpresa = usuarioEmpresa;

    public UsuarioEmpresa UsuarioEmpresa { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AtualizarUsuarioEmpresaRequestValidator>(this);
}