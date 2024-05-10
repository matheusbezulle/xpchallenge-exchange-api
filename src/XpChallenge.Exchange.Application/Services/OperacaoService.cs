using XpChallenge.Exchange.Application.Services.Interfaces;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Exchange.Application.Services
{
    public class OperacaoService(IOperacaoRepository operacaoRepository) : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository = operacaoRepository;

        public Task<List<Operacao>> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            return _operacaoRepository.ObterPorIdClienteAsync(idCliente, cancellationToken);
        }
    }
}
