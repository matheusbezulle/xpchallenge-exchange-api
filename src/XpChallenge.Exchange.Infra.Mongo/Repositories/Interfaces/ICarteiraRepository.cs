using MongoDB.Bson;
using XpChallenge.Exchange.Domain.AggregateRoots;

namespace XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces
{
    public interface ICarteiraRepository
    {
        Task CriarOuAtualizarAsync(Carteira carteira, CancellationToken cancellationToken);
        Task<Carteira> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken);
    }
}
