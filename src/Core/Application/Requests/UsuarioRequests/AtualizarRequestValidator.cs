using Application.Interfaces;
using FluentValidation;

namespace Application.Requests.UsuarioRequests;

public class AtualizarRequestValidator : AbstractValidator<AtualizarRequest>
{
    public AtualizarRequestValidator()
    {
        RuleFor(x => x.Usuario)
            .NotNull()
            .WithMessage("O usuário não pode ser nulo.");

        RuleFor(x => x.Usuario.Nome)
            .NotNull().WithMessage("O Nome é obrigatório.");

        RuleFor(x => x.Usuario.Cpf)
            .NotNull().WithMessage("O CPF é obrigatório.").Length(11)
        .Must(ValidaçãoCPF).WithMessage("O CPF fornecido é inválido.");

        RuleFor(x => x.Usuario.NomeDaMae)
            .NotNull().WithMessage("O Nome da Mãe é obrigatório.");

        RuleFor(x => x.Usuario.NomeDoPai)
            .NotNull().WithMessage("O Nome do Pai é obrigatório.");

        RuleFor(x => x.Usuario.Email)
            .NotNull().WithMessage("O Email é obrigatório.")
            .EmailAddress().WithMessage("O Email fornecido é inválido.");

        RuleFor(x => x.Usuario.DataNascimento)
            .NotNull().WithMessage("A Data de Nascimento é obrigatória.");
    }

    private bool ValidaçãoCPF(string cpf)
    {
        if (string.IsNullOrEmpty(cpf))
            return false;

        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        var equalDigits = true;
        for (var i = 1; i < 11 && equalDigits; i++)
            if (cpf[i] != cpf[0])
                equalDigits = false;

        if (equalDigits || cpf == "12345678909")
            return false;

        var numbers = new int[11];

        for (var i = 0; i < 11; i++)
            numbers[i] = int.Parse(cpf[i].ToString());

        var sum = 0;
        for (var i = 0; i < 9; i++)
            sum += (10 - i) * numbers[i];

        var result = sum % 11;
        if (result == 1 || result == 0)
        {
            if (numbers[9] != 0)
                return false;
        }
        else if (numbers[9] != 11 - result)
            return false;

        sum = 0;
        for (var i = 0; i < 10; i++)
            sum += (11 - i) * numbers[i];

        result = sum % 11;
        if (result == 1 || result == 0)
        {
            if (numbers[10] != 0)
                return false;
        }
        else if (numbers[10] != 11 - result)
            return false;

        return true;
    }

}