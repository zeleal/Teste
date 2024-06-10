using FluentValidation;

namespace Application.Requests.UsuarioRequests;

public class AtualizarRequestValidator : AbstractValidator<AtualizarRequest>
{
    public AtualizarRequestValidator() 
        => RuleFor(x => x.Usuario)
            .NotNull()
            .WithMessage("O usuário não pode ser nulo.");

}