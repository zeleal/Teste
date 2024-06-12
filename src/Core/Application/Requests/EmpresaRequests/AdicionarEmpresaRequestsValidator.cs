using FluentValidation;

namespace Application.Requests.EmpresaRequests;

public class AdicionarEmpresaRequestsValidator : AbstractValidator<AdicionarEmpresaRequests>
{
    public AdicionarEmpresaRequestsValidator()
    {
        RuleFor(x => x.Empresa)
            .NotNull()
            .WithMessage("A empresa não pode ser nulo.");
        //RuleFor(x => x.Empresa.NomeFantasia).NotEmpty().WithMessage("O NomeFantasia não pode ser nulo.");
        //RuleFor(x => x.Empresa.RazaoSocial).NotEmpty().WithMessage("A RazaoSocial não pode ser nulo.");
        //RuleFor(x => x.Empresa.CNPJ)
        //    .NotEmpty().WithMessage("O CNPJ não pode ser nulo.")
        //    .Matches(@"^[0-9]{14}$").WithMessage("O CNPJ deve conter apenas números e ter 14 dígitos.");
    }
}