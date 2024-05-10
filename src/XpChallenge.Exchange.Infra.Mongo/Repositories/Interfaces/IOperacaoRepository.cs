using XpChallenge.Exchange.Domain.AggregateRoots;

namespace XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces
{
    public interface IOperacaoRepository
    {
        Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken);
        Task CriarAsync(Operacao operacao, CancellationToken cancellationToken);
    }
}
