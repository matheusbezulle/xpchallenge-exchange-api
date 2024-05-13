using MediatR;
using XpChallenge.Investimento.Application.Notifications;
using XpChallenge.Investimento.Application.Services.Interfaces;
using XpChallenge.Investimento.Domain.AggregateRoots;
using XpChallenge.Investimento.Domain.ValueObjects;

namespace XpChallenge.Investimento.Application.Commands.ComprarProdutoFinanceiro
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
