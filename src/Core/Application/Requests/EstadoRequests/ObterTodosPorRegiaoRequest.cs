using System.Threading.Tasks;
using Shared;
using Shared.Messages;

namespace Application.Requests.EstadoRequests;

public class ObterTodosPorRegiaoRequest : BaseRequestWithValidation
{
    public ObterTodosPorRegiaoRequest(string regiao) => Regiao = regiao;

    public string Regiao { get; }

    public override async Task ValidateAsync()
        => ValidationResult = await LazyValidator.ValidateAsync<ObterTodosPorRegiaoRequestValidator>(this);
}