using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests
{
    public class ObterUsuarioPorEmpresaRequest : BaseRequestWithValidation
    {
        public ObterUsuarioPorEmpresaRequest(string cnpj) => Cnpj = cnpj;

        public string Cnpj { get; }

        public override async Task ValidateAsync()
            => ValidationResult = await LazyValidator.ValidateAsync<ObterUsuarioPorEmpresaRequestValidator>(this);
    }
}