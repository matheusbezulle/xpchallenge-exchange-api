using MediatR;
using Microsoft.AspNetCore.Mvc;
using XpChallenge.Exchange.Application.Notifications;
using XpChallenge.Exchange.Application.Queries.ObterExtrato;

namespace XpChallenge.Exchange.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController(IMediator mediator,
        INotificator notificator) : ControllerBase(notificator)
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Método para obter o extrato de operações de determinado cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{idCliente}/extrato")]
        public async Task<IActionResult> ObterExtrato(Guid idCliente, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new ObterExtratoQuery(idCliente), cancellationToken);
            return ProcessarRetorno(result);
        }
    }
}
