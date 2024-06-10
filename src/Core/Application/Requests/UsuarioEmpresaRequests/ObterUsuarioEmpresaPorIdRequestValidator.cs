using FluentValidation;

namespace Application.Requests.UsuarioEmpresaRequests;

public class ObterUsuarioEmpresaPorIdRequestValidator : AbstractValidator<ObterUsuarioEmpresaPorIdRequest>
{
    public ObterUsuarioEmpresaPorIdRequestValidator()
    {
        RuleFor(x => x.UsuarioId)
            .NotEmpty()
            .WithMessage("O ID do usuário não pode ser vazio.");

        RuleFor(x => x.EmpresaId)
            .NotEmpty()
            .WithMessage("O ID da empresa não pode ser vazio.");
    }
}