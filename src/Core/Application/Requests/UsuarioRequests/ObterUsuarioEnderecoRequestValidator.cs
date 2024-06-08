using Application.Requests.EnderecoRequests;
using FluentValidation;

namespace Application.Requests.UsuarioRequests
{
    public class ObterUsuarioEnderecoRequestValidator : AbstractValidator<ObterUsuarioEnderecoRequest>
    {
        public ObterUsuarioEnderecoRequestValidator()
            => RuleFor(req => req.Id).NotEmpty();
    }
}