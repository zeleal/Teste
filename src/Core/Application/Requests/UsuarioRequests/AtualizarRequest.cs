using Domain.Dto;
using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioRequests;

public class AtualizarRequest : BaseRequestWithValidation
{
    public AtualizarRequest(Usuario usuario) => Usuario = usuario;

    public Usuario Usuario { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AtualizarRequestValidator>(this);
}