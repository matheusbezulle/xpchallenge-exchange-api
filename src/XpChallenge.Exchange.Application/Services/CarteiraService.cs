using XpChallenge.Exchange.Application.Services.Interfaces;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Exchange.Application.Services
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
