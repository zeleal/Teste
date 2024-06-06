using System.Threading.Tasks;
using Shared;
using Shared.Messages;

namespace Application.Requests.CidadeRequests;

public class ObterTodosPorUfRequest : BaseRequestWithValidation
{
    public ObterTodosPorUfRequest(string uf) => Uf = uf;

    public string Uf { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<ObterTodosPorUfRequestValidator>(this);
}