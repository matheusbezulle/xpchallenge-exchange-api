using MediatR;
using Microsoft.AspNetCore.Mvc;
using XpChallenge.Exchange.Api.Requests;
using XpChallenge.Exchange.Application.Commands.ComprarProdutoFinanceiro;
using XpChallenge.Exchange.Application.Notifications;

namespace XpChallenge.Exchange.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController(IMediator mediator,
        INotificator notificator) : ControllerBase(notificator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("[controller]/Comprar")]
        public async Task<IActionResult> Comprar([FromBody] ComprarProdutoFinanceiroRequest request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new ComprarProdutoFinanceiroCommand(request.IdCliente, request.NomeProdutoFinanceiro, request.Quantidade), cancellationToken);
            return ProcessarRetorno();
        }

        [HttpPost("[controller]/Vender")]
        public async Task<IActionResult> Vender([FromBody] ComprarProdutoFinanceiroRequest request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new ComprarProdutoFinanceiroCommand(request.IdCliente, request.NomeProdutoFinanceiro, request.Quantidade), cancellationToken);
            return ProcessarRetorno();
        }
    }
}
