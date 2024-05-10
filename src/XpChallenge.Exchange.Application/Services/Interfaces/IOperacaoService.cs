using XpChallenge.Exchange.Domain.AggregateRoots;

namespace XpChallenge.Exchange.Application.Services.Interfaces
{
    public interface IOperacaoService
    {
        Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken);
    }
}
