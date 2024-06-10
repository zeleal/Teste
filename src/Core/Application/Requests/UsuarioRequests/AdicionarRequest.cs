using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioRequests;

public class AdicionarRequest : BaseRequestWithValidation
{
    public AdicionarRequest(Usuario usuario) => Usuario = usuario;

    public Usuario Usuario { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AdicionarRequestValidator>(this);
}