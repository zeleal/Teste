using FluentValidation;
using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioRequests;

public class ExcluirRequestValidator : AbstractValidator<ExcluirRequest>
{
    public ExcluirRequestValidator() => 
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID não pode ser vazio.");
}