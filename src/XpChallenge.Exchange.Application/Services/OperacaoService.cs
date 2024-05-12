using MongoDB.Bson;
using MongoDB.Driver;
using XpChallenge.Exchange.Application.Services.Interfaces;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Domain.ValueObjects;
using XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Exchange.Application.Services
{
    public class OperacaoService(IOperacaoRepository operacaoRepository,
        ICarteiraRepository carteiraRepository,
        IMongoClient mongoClient) : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository = operacaoRepository;
        private readonly ICarteiraRepository _carteiraRepository = carteiraRepository;
        private readonly IMongoClient _client = mongoClient;

        public Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            return _operacaoRepository.ObterPorIdClienteAsync(idCliente, cancellationToken);
        }

        public async Task RegistrarOperacaoAsync(Carteira carteira, Operacao operacao, CancellationToken cancellationToken)
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
                await _operacaoRepository.CriarAsync(operacao, cancellationToken);

                await session.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await session.AbortTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
}
