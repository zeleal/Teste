using FluentValidation;

namespace Application.Requests.UsuarioRequests;

public class AdicionarRequestValidator : AbstractValidator<AdicionarRequest>
{
    public AdicionarRequestValidator() 
        => RuleFor(x => x.Usuario)
            .NotNull()
            .WithMessage("O usuário não pode ser nulo.");
}