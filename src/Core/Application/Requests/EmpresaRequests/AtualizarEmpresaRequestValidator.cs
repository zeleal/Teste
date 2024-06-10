using FluentValidation;

namespace Application.Requests.EmpresaRequests;

public class AtualizarEmpresaRequestValidator : AbstractValidator<AtualizarEmpresaRequest>
{
    public AtualizarEmpresaRequestValidator()
        => RuleFor(x => x.Empresa)
            .NotNull()
            .WithMessage("A empresa não pode ser nulo.");
}