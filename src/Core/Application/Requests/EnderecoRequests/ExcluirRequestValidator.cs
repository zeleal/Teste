using FluentValidation;

namespace Application.Requests.EnderecoRequests;

public class ExcluirRequestValidator : AbstractValidator<ExcluirRequest>
{
    public ExcluirRequestValidator() =>
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID não pode ser vazio.");
}