using Shared;
using Shared.Messages;

namespace Application.Requests.UsuarioEmpresaRequests
{
    public class ObterEmpresaPorUsuarioRequest : BaseRequestWithValidation
    {
        public ObterEmpresaPorUsuarioRequest(int cpf) => Cpf = cpf;

        public int Cpf { get; }

        public override async Task ValidateAsync()
            => ValidationResult = await LazyValidator.ValidateAsync<ObterEmpresaPorUsuarioRequestValidator>(this);
    }
}