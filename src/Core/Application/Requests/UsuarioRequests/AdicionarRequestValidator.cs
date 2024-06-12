using Application.Interfaces;
using FluentValidation;

namespace Application.Requests.UsuarioRequests;

public class AdicionarRequestValidator : AbstractValidator<AdicionarRequest>
{
    private IUsuarioService _usuarioService;
    public AdicionarRequestValidator()
    {
        RuleFor(x => x.Usuario)
            .NotNull()
            .WithMessage("O usuário não pode ser nulo.");

        //RuleFor(x => x.Usuario.Nome)
        //    .NotEmpty().WithMessage("O Nome é obrigatório.");

        //RuleFor(x => x.Usuario.Cpf)
        //    .NotEmpty().WithMessage("O CPF é obrigatório.").Length(11);
        //    //.Must(_usuarioService.ValidaçãoCPF).WithMessage("O CPF fornecido é inválido.");

        //RuleFor(x => x.Usuario.NomeDaMae)
        //    .NotEmpty().WithMessage("O Nome da Mãe é obrigatório.");

        //RuleFor(x => x.Usuario.NomeDoPai)
        //    .NotEmpty().WithMessage("O Nome do Pai é obrigatório.");

        //RuleFor(x => x.Usuario.Email)
        //    .NotEmpty().WithMessage("O Email é obrigatório.")
        //    .EmailAddress().WithMessage("O Email fornecido é inválido.");

        //RuleFor(x => x.Usuario.DataNascimento)
        //    .NotEmpty().WithMessage("A Data de Nascimento é obrigatória.");
    }
}