using Domain.Dto;
using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.EnderecoRequests;

public class AdicionarRequest : BaseRequestWithValidation
{
    public AdicionarRequest(EnderecoDto endereco) => Endereco = endereco;

    public EnderecoDto Endereco { get; }
    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AdicionarRequestValidator>(this);
}