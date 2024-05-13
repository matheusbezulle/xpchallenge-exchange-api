using MediatR;
using Microsoft.AspNetCore.Mvc;
using XpChallenge.Investimento.Api.Requests;
using XpChallenge.Investimento.Application.Commands.ComprarProdutoFinanceiro;
using XpChallenge.Investimento.Application.Commands.VenderProdutoFinanceiro;
using XpChallenge.Investimento.Application.Notifications;

namespace XpChallenge.Investimento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController(IMediator mediator,
        INotificator notificator) : ControllerBase(notificator)
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Método responsável por enviar uma ordem de compra na carteira de determinado cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("/Comprar")]
        public async Task<IActionResult> Comprar([FromBody] ComprarProdutoFinanceiroRequest request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new ComprarProdutoFinanceiroCommand(request.IdCliente, request.NomeProdutoFinanceiro, request.Quantidade), cancellationToken);
            return ProcessarRetorno();
        }

        /// <summary>
        /// Método responsável por enviar uma ordem de venda na carteira de determinado cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("/Vender")]
        public async Task<IActionResult> Vender([FromBody] VenderProdutoFinanceiroRequest request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new VenderProdutoFinanceiroCommand(request.IdCliente, request.NomeProdutoFinanceiro, request.Quantidade), cancellationToken);
            return ProcessarRetorno();
        }
    }
}
