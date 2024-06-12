﻿using FluentValidation;

namespace Application.Requests.EnderecoRequests;

public class AtualizarRequestValidator : AbstractValidator<AtualizarRequest>
{
    public AtualizarRequestValidator()
    {
        RuleFor(x => x.Endereco)
            .NotNull()
            .WithMessage("O endereço não pode ser nulo.");
        RuleFor(x => x.Endereco.UsuarioId)
            .NotEmpty()
            .WithMessage("O Campo UsuarioId não pode estar vazio.");

        RuleFor(x => x.Endereco.Cep)
            .NotEmpty().WithMessage("O CEP é obrigatório.")
            .Matches(@"^\d{5}-\d{3}$").WithMessage("O CEP deve estar no formato XXXXX-XXX.");

        RuleFor(x => x.Endereco.Bairro).NotEmpty().WithMessage("O Bairro não pode ser vazio.");
        RuleFor(x => x.Endereco.Rua).NotEmpty().WithMessage("A Rua não pode ser vazio.");
    }
}