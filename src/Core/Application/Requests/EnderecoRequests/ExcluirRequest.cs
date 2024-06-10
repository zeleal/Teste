using Shared;
using Shared.Messages;

namespace Application.Requests.EnderecoRequests;

public class ExcluirRequest : BaseRequestWithValidation
{
    public ExcluirRequest(Guid id) => Id = id;

    public Guid Id { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<ExcluirRequestValidator>(this);
}