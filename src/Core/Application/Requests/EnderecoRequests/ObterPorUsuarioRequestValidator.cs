using Application.Requests.CidadeRequests;
using FluentValidation;

namespace Application.Requests.EnderecoRequests
{
    public class ObterPorUsuarioRequestValidator : AbstractValidator<ObterPorUsuarioRequest>
    {
        public ObterPorUsuarioRequestValidator()
            => RuleFor(req => req.UsuarioId).NotEmpty();
    }
}