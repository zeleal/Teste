using FluentValidation;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests
{
    public class ObterUsuarioPorEmpresaRequestValidator : AbstractValidator<ObterUsuarioPorEmpresaRequest>
    {
        public ObterUsuarioPorEmpresaRequestValidator()
            => RuleFor(req => req.Cnpj).NotEmpty();
    }
}