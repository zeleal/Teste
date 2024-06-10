using FluentValidation;

namespace Application.Requests.UsuarioEmpresaRequests;

public class AtualizarUsuarioEmpresaRequestValidator : AbstractValidator<AtualizarUsuarioEmpresaRequest>
{
    public AtualizarUsuarioEmpresaRequestValidator() 
        => RuleFor(x => x.UsuarioEmpresa)
            .NotNull()
            .WithMessage("O usuário-empresa não pode ser nulo.");

}