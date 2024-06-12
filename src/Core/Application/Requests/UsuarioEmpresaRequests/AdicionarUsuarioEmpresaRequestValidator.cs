using FluentValidation;

namespace Application.Requests.UsuarioEmpresaRequests;

public class AdicionarUsuarioEmpresaRequestValidator : AbstractValidator<AdicionarUsuarioEmpresaRequest>
{
    public AdicionarUsuarioEmpresaRequestValidator()
    {
         RuleFor(x => x.UsuarioEmpresa)
            .NotNull()
            .WithMessage("O usuário-empresa não pode ser nulo.");
         //RuleFor(x => x.UsuarioEmpresa.EmpresaId).NotEmpty().WithMessage("É necessário inserir a EmpresaId.");
         //RuleFor(x => x.UsuarioEmpresa.UsuarioId).NotEmpty().WithMessage("É necessário inserir o UsuarioId.");
    }

}