using MediatR;
using XpChallenge.Exchange.Application.Notifications;
using XpChallenge.Exchange.Application.Services.Interfaces;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Domain.ValueObjects;

namespace XpChallenge.Exchange.Application.Commands.ComprarProdutoFinanceiro
{
    public class ComprarProdutoFinanceiroCommandHandler(IProdutoFinanceiroService produtoFinanceiroService,
        ICarteiraService carteiraService,
        IOperacaoService operacaoService,
        INotificator notificator) : IRequestHandler<ComprarProdutoFinanceiroCommand, ComprarProdutoFinanceiroCommandResponse>
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService = produtoFinanceiroService;
        private readonly ICarteiraService _carteiraService = carteiraService;
        private readonly IOperacaoService _operacaoService = operacaoService;
        private readonly INotificator _notificator = notificator;

        public async Task<ComprarProdutoFinanceiroCommandResponse> Handle(ComprarProdutoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            var response = new ComprarProdutoFinanceiroCommandResponse();

            var cotacaoAtual = await _produtoFinanceiroService.ObterCotacaoAtualAsync(request.NomeProdutoFinanceiro, cancellationToken);
            
            if (!cotacaoAtual.HasValue)
            {
                _notificator.AdicionarErroNegocio("Não foi possível encontrar produto financeiro informado.");
                return response;
            }

            var carteira = await _carteiraService.ObterPorIdClienteAsync(request.IdCliente, cancellationToken)
                ?? new Carteira(request.IdCliente);

            carteira.AdicionarProdutoFinanceiro(request.NomeProdutoFinanceiro, request.Quantidade, cotacaoAtual.Value);

            var operacao = new Operacao(request.IdCliente,
                TipoOperacao.Compra,
                request.NomeProdutoFinanceiro,
                cotacaoAtual.Value,
                request.Quantidade);

            await _operacaoService.RegistrarOperacaoAsync(carteira, operacao, cancellationToken);

            return response;
        }
    }
}
