using FluentValidation;

namespace Application.Requests.EmpresaRequests;

public class ExcluirEmpresaRequestValidator : AbstractValidator<ExcluirEmpresaRequest>
{
    public ExcluirEmpresaRequestValidator() =>
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID não pode ser vazio.");
}