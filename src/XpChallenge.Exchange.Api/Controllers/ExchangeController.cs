using MediatR;
using Microsoft.AspNetCore.Mvc;
using XpChallenge.Exchange.Application.Notifications;

namespace XpChallenge.Exchange.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController(IMediator mediator,
        INotificator notificator) : ControllerBase(notificator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("[controller]/comprar")]
        public async Task<IActionResult> Comprar(CancellationToken cancellationToken = default)
        {
            //await _mediator.Send(new CriarPortfolioCommand(request.Nome, request.IdPerfil), cancellationToken);
            return ProcessarRetorno();
        }
    }
}
