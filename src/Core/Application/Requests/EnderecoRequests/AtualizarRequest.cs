using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.EnderecoRequests;

public class AtualizarRequest : BaseRequestWithValidation
{
    public AtualizarRequest(Endereco endereco) => Endereco = endereco;

    public Endereco Endereco { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AtualizarRequestValidator>(this);
}