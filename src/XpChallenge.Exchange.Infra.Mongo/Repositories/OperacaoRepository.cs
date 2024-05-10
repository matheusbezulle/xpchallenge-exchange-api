using MongoDB.Driver;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Exchange.Infra.Mongo.Repositories
{
    public class OperacaoRepository(IMongoDatabase database) : IOperacaoRepository
    {
        private readonly IMongoCollection<Operacao> _operacaoCollection = database.GetCollection<Operacao>("Operacoes");

        public async Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            var filter = Builders<Operacao>.Filter
                .Eq(o => o.IdCliente, idCliente);

            return await _operacaoCollection.Find(filter).ToListAsync(cancellationToken);
        }

        public async Task CriarAsync(Operacao operacao, CancellationToken cancellationToken)
        {
            await _operacaoCollection.InsertOneAsync(operacao, cancellationToken: cancellationToken);
        }
    }
}
