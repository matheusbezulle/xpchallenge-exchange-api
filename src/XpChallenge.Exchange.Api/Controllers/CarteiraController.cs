using MediatR;
using Microsoft.AspNetCore.Mvc;
using XpChallenge.Exchange.Application.Notifications;
using XpChallenge.Exchange.Application.Queries.ObterCarteira;
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
        /// Obter o extrato de operações de determinado cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{idCliente}/extrato")]
        public async Task<IActionResult> ObterExtratoAsync(Guid idCliente, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new ObterExtratoQuery(idCliente), cancellationToken);
            return ProcessarRetorno(result);
        }

        /// <summary>
        /// Obter os dados da carteira de determinado cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{idCliente}")]
        public async Task<IActionResult> ObterAsync(Guid idCliente, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new ObterCarteiraQuery(idCliente), cancellationToken);
            return ProcessarRetorno(result);
        }
    }
}
