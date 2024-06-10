using FluentValidation;

namespace Application.Requests.EmpresaRequests;

public class AdicionarEmpresaRequestsValidator : AbstractValidator<AdicionarEmpresaRequests>
{
    public AdicionarEmpresaRequestsValidator()
        => RuleFor(x => x.Empresa)
            .NotNull()
            .WithMessage("A empresa não pode ser nulo.");
}