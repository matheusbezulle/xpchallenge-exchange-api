using MongoDB.Driver;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Exchange.Infra.Mongo.Repositories
{
    public class CarteiraRepository(IMongoDatabase database) : ICarteiraRepository
    {
        private readonly IMongoCollection<Carteira> _carteiraCollection = database.GetCollection<Carteira>("Carteiras");

        public async Task CriarOuAtualizarAsync(Carteira carteira, CancellationToken cancellationToken)
        {
            var replaceResult = await _carteiraCollection.ReplaceOneAsync(c => c.IdCliente.Equals(carteira.IdCliente),
                carteira,
                cancellationToken: cancellationToken,
                options: new ReplaceOptions
                {
                    IsUpsert = true
                });

            if (!replaceResult.IsAcknowledged)
                throw new Exception("Não foi possível criar ou atualizar a carteira do cliente. Tente novamente.");
        }

        public async Task<Carteira> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            var filter = Builders<Carteira>.Filter
                .Eq(o => o.IdCliente, idCliente);

            return await _carteiraCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
