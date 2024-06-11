using Domain.Dto;
using Domain.Entities;
using Shared;
using Shared.Messages;

namespace Application.Requests.EmpresaRequests;

public class AtualizarEmpresaRequest : BaseRequestWithValidation
{
    public AtualizarEmpresaRequest(EmpresaDto empresa) => Empresa = empresa;

    public EmpresaDto Empresa { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<AtualizarEmpresaRequestValidator>(this);
}