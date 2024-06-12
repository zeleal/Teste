using Domain.Dto;
using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.EnderecoRequests;

public class AtualizarRequest : BaseRequestWithValidation
{
    public AtualizarRequest(EnderecoDto endereco) => Endereco = endereco;

    public EnderecoDto Endereco { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AtualizarRequestValidator>(this);
}