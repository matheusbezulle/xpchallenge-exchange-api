using MongoDB.Driver;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Exchange.Infra.Mongo.Repositories
{
    public class CarteiraRepository(IMongoDatabase database) : ICarteiraRepository
    {
        private readonly IMongoCollection<Carteira> _carteiraCollection = database.GetCollection<Carteira>("Carteiras");

        public async Task<Carteira> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            var filter = Builders<Carteira>.Filter
                .Eq(o => o.IdCliente, idCliente);

            return await _carteiraCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task CriarAsync(Carteira carteira, CancellationToken cancellationToken)
        {
            await _carteiraCollection.InsertOneAsync(carteira, cancellationToken: cancellationToken);
        }

        public async Task AtualizarAsync(Carteira carteira, CancellationToken cancellationToken)
        {
            var filter = Builders<Carteira>.Filter
                .Eq(c => c.Id, carteira.Id);

            var update = Builders<Carteira>.Update
                .Set(c => c.ProdutosFinanceiros, carteira.ProdutosFinanceiros);

            var result = await _carteiraCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

            if (!result.IsAcknowledged)
                throw new Exception("Não foi possível atualizar a carteira na base. Tente novamente.");
        }
    }
}
