using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Exchange.Infra.Mongo.Repositories
{
    public class OperacaoRepository(ICarteiraRepository carteiraRepository,
        IMongoDatabase database,
        IMongoClient mongoClient,
        ILogger<OperacaoRepository> logger) : IOperacaoRepository
    {
        private readonly ICarteiraRepository _carteiraRepository = carteiraRepository;
        private readonly IMongoCollection<Operacao> _operacaoCollection = database.GetCollection<Operacao>("Operacoes");
        private readonly IMongoClient _client = mongoClient;
        private readonly ILogger<OperacaoRepository> _logger = logger;

        public async Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            var filter = Builders<Operacao>.Filter
                .Eq(o => o.IdCliente, idCliente);

            var sort = Builders<Operacao>.Sort.Descending("Data");

            return await _operacaoCollection.Find(filter).Sort(sort).ToListAsync(cancellationToken);
        }

        public async Task CriarAsync(Carteira carteira, Operacao operacao, CancellationToken cancellationToken)
        {
            using var session = await _client.StartSessionAsync(cancellationToken: cancellationToken);
            session.StartTransaction();
            try
            {
                if (carteira.Id == ObjectId.Empty)
                {
                    await _carteiraRepository.CriarAsync(carteira, cancellationToken);
                }
                else
                {
                    await _carteiraRepository.AtualizarAsync(carteira, cancellationToken);
                }
                await _operacaoCollection.InsertOneAsync(operacao, cancellationToken: cancellationToken);

                await session.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync(cancellationToken);
                _logger.LogError(ex, "Falha ao tentar incluir operação de compra/venda.");
                throw new Exception("Não foi possível registrar a operação de compra/venda solicitada. Tente novamente.");
            }            
        }
    }
}
