using FluentValidation;

namespace Application.Requests.EnderecoRequests;

public class AtualizarRequestValidator : AbstractValidator<AtualizarRequest>
{
    public AtualizarRequestValidator()
        => RuleFor(x => x.Endereco)
            .NotNull()
            .WithMessage("O endereço não pode ser nulo.");
}