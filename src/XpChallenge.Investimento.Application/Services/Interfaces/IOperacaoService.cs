using XpChallenge.Investimento.Domain.AggregateRoots;

namespace XpChallenge.Investimento.Application.Services.Interfaces
{
    public interface IOperacaoService
    {
        Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken);
        Task RegistrarOperacaoAsync(Carteira carteira, Operacao operacao, CancellationToken cancellationToken);
    }
}
