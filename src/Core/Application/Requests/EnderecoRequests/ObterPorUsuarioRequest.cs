using Application.Requests.CidadeRequests;
using Shared;
using Shared.Messages;

namespace Application.Requests.EnderecoRequests
{
    public class ObterPorUsuarioRequest : BaseRequestWithValidation
    {
        public ObterPorUsuarioRequest(Guid usuarioId) => UsuarioId = usuarioId;

        public Guid UsuarioId { get; }

        public override async Task ValidateAsync()
            => ValidationResult = await LazyValidator.ValidateAsync<ObterPorUsuarioRequestValidator>(this);
    }
}