using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.EmpresaRequests;

public class AdicionarEmpresaRequests : BaseRequestWithValidation
{
    public AdicionarEmpresaRequests(Empresa empresa) => Empresa = empresa;

    public Empresa Empresa { get; }
    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AdicionarEmpresaRequestsValidator>(this);
}