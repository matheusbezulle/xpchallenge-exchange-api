using MapsterMapper;
using MediatR;
using XpChallenge.Investimento.Application.DataTransfer;
using XpChallenge.Investimento.Application.Notifications;
using XpChallenge.Investimento.Application.Services.Interfaces;

namespace XpChallenge.Investimento.Application.Queries.ObterCarteira
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
