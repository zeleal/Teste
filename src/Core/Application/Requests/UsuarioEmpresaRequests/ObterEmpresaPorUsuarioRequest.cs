using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests
{
    public class ObterEmpresaPorUsuarioRequest : BaseRequestWithValidation
    {
        public ObterEmpresaPorUsuarioRequest(string cpf) => Cpf = cpf;

        public string Cpf { get; }

        public override async Task ValidateAsync()
            => ValidationResult = await LazyValidator.ValidateAsync<ObterEmpresaPorUsuarioRequestValidator>(this);
    }
}