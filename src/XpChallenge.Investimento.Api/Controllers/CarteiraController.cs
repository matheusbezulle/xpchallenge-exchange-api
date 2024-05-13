using MediatR;
using Microsoft.AspNetCore.Mvc;
using XpChallenge.Investimento.Application.Notifications;
using XpChallenge.Investimento.Application.Queries.ObterCarteira;
using XpChallenge.Investimento.Application.Queries.ObterExtrato;

namespace XpChallenge.Investimento.Api.Controllers
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
        [HttpGet("{idCliente}/Extrato")]
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
