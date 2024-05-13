using XpChallenge.Investimento.Domain.AggregateRoots;

namespace XpChallenge.Investimento.Application.Services.Interfaces
{
    public interface ICarteiraService
    {
        Task<Carteira> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken);
    }
}
