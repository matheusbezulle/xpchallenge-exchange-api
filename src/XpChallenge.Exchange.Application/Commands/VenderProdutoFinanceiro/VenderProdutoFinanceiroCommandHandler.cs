using MediatR;
using XpChallenge.Exchange.Application.Notifications;
using XpChallenge.Exchange.Application.Services.Interfaces;
using XpChallenge.Exchange.Domain.AggregateRoots;
using XpChallenge.Exchange.Domain.ValueObjects;

namespace XpChallenge.Exchange.Application.Commands.VenderProdutoFinanceiro
{
    public class VenderProdutoFinanceiroCommandHandler(IProdutoFinanceiroService produtoFinanceiroService,
        ICarteiraService carteiraService,
        IOperacaoService operacaoService,
        INotificator notificator) : IRequestHandler<VenderProdutoFinanceiroCommand, VenderProdutoFinanceiroCommandResponse>
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService = produtoFinanceiroService;
        private readonly ICarteiraService _carteiraService = carteiraService;
        private readonly IOperacaoService _operacaoService = operacaoService;
        private readonly INotificator _notificator = notificator;

        public async Task<VenderProdutoFinanceiroCommandResponse> Handle(VenderProdutoFinanceiroCommand request, CancellationToken cancellationToken)
        {
            var response = new VenderProdutoFinanceiroCommandResponse();
            var carteira = await _carteiraService.ObterPorIdClienteAsync(request.IdCliente, cancellationToken);

            if (carteira == null || !carteira.PossuiProdutosFinanceiros())
            {
                _notificator.AdicionarErroNegocio("A carteira informada não existe ou ainda não possui produtos financeiros.");
                return response;
            }

            var produtoFinanceiro = carteira.ObterProdutoFinanceiro(request.NomeProdutoFinanceiro);

            if (produtoFinanceiro == null || produtoFinanceiro.Quantidade < request.Quantidade)
            {
                _notificator.AdicionarErroNegocio($"A carteira informada não possui quantidade suficiente de {request.NomeProdutoFinanceiro} para venda.");
                return response;
            }

            var cotacaoAtual = await _produtoFinanceiroService.ObterCotacaoAtualAsync(request.NomeProdutoFinanceiro, cancellationToken);

            if (!cotacaoAtual.HasValue)
            {
                _notificator.AdicionarErroNegocio("Não foi possível consultar a cotação do produto financeiro informado.");
                return response;
            }

            if (produtoFinanceiro.Quantidade == request.Quantidade)
                carteira.RemoverProdutoFinanceiro(produtoFinanceiro);
            else
                produtoFinanceiro.DiminuirQuantidade(request.Quantidade, cotacaoAtual.Value);

            var operacao = new Operacao(request.IdCliente,
                TipoOperacao.Venda,
                request.NomeProdutoFinanceiro,
                cotacaoAtual.Value,
                request.Quantidade);

            await _operacaoService.RegistrarOperacaoAsync(carteira, operacao, cancellationToken);

            return response;
        }
    }
}
