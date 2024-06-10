using FluentValidation;

namespace Application.Requests.UsuarioEmpresaRequests;

public class AdicionarUsuarioEmpresaRequestValidator : AbstractValidator<AdicionarUsuarioEmpresaRequest>
{
    public AdicionarUsuarioEmpresaRequestValidator() 
        => RuleFor(x => x.UsuarioEmpresa)
            .NotNull()
            .WithMessage("O usuário-empresa não pode ser nulo.");

}