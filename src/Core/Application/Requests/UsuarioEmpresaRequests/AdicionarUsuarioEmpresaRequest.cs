using Domain.Dto;
using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests;

public class AdicionarUsuarioEmpresaRequest : BaseRequestWithValidation
{
    public AdicionarUsuarioEmpresaRequest(UsuarioEmpresaDto usuarioEmpresa) => UsuarioEmpresa = usuarioEmpresa;

    public UsuarioEmpresaDto UsuarioEmpresa { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AdicionarUsuarioEmpresaRequestValidator>(this);
}