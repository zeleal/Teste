using FluentValidation;

namespace Application.Requests.CidadeRequests;

public class ObterPorIbgeRequestValidator : AbstractValidator<ObterPorIbgeRequest>
{
    public ObterPorIbgeRequestValidator()
        => RuleFor(req => req.Ibge).NotEmpty().GreaterThan(0);
}