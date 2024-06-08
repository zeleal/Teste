using Application.Requests.UsuarioRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.EnderecoRequests
{
    public class ObterEnderecoPorUsuarioRequestsValidator : AbstractValidator<ObterEnderecoPorUsuarioRequests>
    {
        public ObterEnderecoPorUsuarioRequestsValidator()
            => RuleFor(req => req.Cpf).NotEmpty().GreaterThan(0);
    }
}
