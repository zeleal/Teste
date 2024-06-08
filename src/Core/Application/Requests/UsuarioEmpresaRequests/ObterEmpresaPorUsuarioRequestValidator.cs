using Application.Requests.CidadeRequests;
using FluentValidation;

namespace Application.Requests.UsuarioEmpresaRequests
{
    public class ObterEmpresaPorUsuarioRequestValidator : AbstractValidator<ObterEmpresaPorUsuarioRequest>
    {
        public ObterEmpresaPorUsuarioRequestValidator()
            => RuleFor(req => req.Cpf).NotEmpty().GreaterThan(0);
    }
}