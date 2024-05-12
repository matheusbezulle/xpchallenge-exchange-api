using XpChallenge.Exchange.Domain.AggregateRoots;

namespace XpChallenge.Exchange.Application.Services.Interfaces
{
    public interface ICarteiraService
    {
        Task<Carteira> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken);
    }
}
