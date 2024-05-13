using XpChallenge.Investimento.Application.Services.Interfaces;
using XpChallenge.Investimento.Domain.AggregateRoots;
using XpChallenge.Investimento.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Investimento.Application.Services
{
    public class OperacaoService(IOperacaoRepository operacaoRepository) : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository = operacaoRepository;

        public Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            return _operacaoRepository.ObterPorIdClienteAsync(idCliente, cancellationToken);
        }

        public async Task RegistrarOperacaoAsync(Carteira carteira, Operacao operacao, CancellationToken cancellationToken)
        {
            await _operacaoRepository.CriarAsync(carteira, operacao, cancellationToken);
        }
    }
}
