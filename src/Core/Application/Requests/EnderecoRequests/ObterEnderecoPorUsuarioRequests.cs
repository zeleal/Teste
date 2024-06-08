using Shared.Messages;
using Shared;

namespace Application.Requests.EnderecoRequests
{
    public class ObterEnderecoPorUsuarioRequests : BaseRequestWithValidation
    {
        public ObterEnderecoPorUsuarioRequests(int cpf) => Cpf = cpf;

        public int Cpf { get; }

        public override async Task ValidateAsync()
            => ValidationResult = await LazyValidator.ValidateAsync<ObterEnderecoPorUsuarioRequestsValidator>(this);
    }
}