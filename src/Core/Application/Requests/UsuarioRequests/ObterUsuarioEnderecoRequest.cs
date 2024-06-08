using Application.Requests.EnderecoRequests;
using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioRequests
{
    public class ObterUsuarioEnderecoRequest : BaseRequestWithValidation
    {
        public ObterUsuarioEnderecoRequest(Guid id) => Id = id;

        public Guid Id { get; }

        public override async Task ValidateAsync()
            => ValidationResult = await LazyValidator.ValidateAsync<ObterEnderecoPorUsuarioRequestsValidator>(this);
    }
}