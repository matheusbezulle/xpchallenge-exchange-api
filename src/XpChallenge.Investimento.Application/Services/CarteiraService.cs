using XpChallenge.Investimento.Application.Services.Interfaces;
using XpChallenge.Investimento.Domain.AggregateRoots;
using XpChallenge.Investimento.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Investimento.Application.Services
{
    public class CarteiraService(ICarteiraRepository carteiraRepository) : ICarteiraService
    {
        private readonly ICarteiraRepository _carteiraRepository = carteiraRepository;
        
        public Task<Carteira> ObterPorIdClienteAsync(Guid idCliente, CancellationToken cancellationToken)
        {
            return _carteiraRepository.ObterPorIdClienteAsync(idCliente, cancellationToken);
        }
    }
}
