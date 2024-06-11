using Domain.Dto;
using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests;

public class AdicionarUsuarioEmpresaRequest : BaseRequestWithValidation
{
    public AdicionarUsuarioEmpresaRequest(UsuarioEmpresa usuarioEmpresa) => UsuarioEmpresa = usuarioEmpresa;

    public UsuarioEmpresa UsuarioEmpresa { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AdicionarUsuarioEmpresaRequestValidator>(this);
}