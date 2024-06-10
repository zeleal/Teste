using FluentValidation;

namespace Application.Requests.EnderecoRequests;

public class AdicionarRequestValidator : AbstractValidator<AdicionarRequest>
{
    public AdicionarRequestValidator()
        => RuleFor(x => x.Endereco)
            .NotNull()
            .WithMessage("O endereco não pode ser nulo.");
}