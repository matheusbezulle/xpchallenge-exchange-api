using MapsterMapper;
using MediatR;
using XpChallenge.Exchange.Application.DataTransfer;
using XpChallenge.Exchange.Application.Notifications;
using XpChallenge.Exchange.Application.Services.Interfaces;

namespace XpChallenge.Exchange.Application.Queries.ObterCarteira
{
    public class ObterCarteiraQueryHandler(ICarteiraService carteiraService,
        IMapper mapper,
        INotificator notificator) : IRequestHandler<ObterCarteiraQuery, ObterCarteiraQueryResponse>
    {
        private readonly ICarteiraService _carteiraService = carteiraService;
        private readonly IMapper _mapper = mapper;
        private readonly INotificator _notificator = notificator;

        public async Task<ObterCarteiraQueryResponse> Handle(ObterCarteiraQuery request, CancellationToken cancellationToken)
        {
            var response = new ObterCarteiraQueryResponse();

            var carteira = await _carteiraService.ObterPorIdClienteAsync(request.IdCliente, cancellationToken);

            if (carteira == null)
            {
                _notificator.AdicionarErroNegocio("A carteira informada não foi encontrada.");
                return response;
            }

            response.Carteira = _mapper.Map<CarteiraDto>(carteira);

            return response;
        }
    }
}
