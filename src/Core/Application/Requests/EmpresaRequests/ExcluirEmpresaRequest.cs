using Shared;
using Shared.Messages;

namespace Application.Requests.EmpresaRequests;

public class ExcluirEmpresaRequest : BaseRequestWithValidation
{
    public ExcluirEmpresaRequest(Guid id) => Id = id;

    public Guid Id { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<ExcluirEmpresaRequestValidator>(this);
}