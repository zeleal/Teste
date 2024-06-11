using Domain.Dto;
using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioRequests;

public class AdicionarRequest : BaseRequestWithValidation
{
    public AdicionarRequest(UsuarioDto usuario) => Usuario = usuario;

    public UsuarioDto Usuario { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AdicionarRequestValidator>(this);
}