using MongoDB.Bson;
using XpChallenge.Exchange.Domain.AggregateRoots;

namespace XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces
{
    public interface ICarteiraRepository
    {
        Task<Carteira> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken);
        Task CriarAsync(Carteira carteira, CancellationToken cancellationToken);
        Task AtualizarAsync(Carteira carteira, CancellationToken cancellationToken);
    }
}
