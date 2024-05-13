using XpChallenge.Investimento.Application.Services.Interfaces;
using XpChallenge.Investimento.Infra.External.Clients.Interfaces;

namespace XpChallenge.Investimento.Application.Services
{
    public class ProdutoFinanceiroService(IAlphaVantageClient alphaVantageClient) : IProdutoFinanceiroService
    {
        private readonly IAlphaVantageClient _alphaVantageClient = alphaVantageClient;

        public async Task<decimal?> ObterCotacaoAtualAsync(string nomeProdutoFinanceiro, CancellationToken cancellationToken)
        {
            var cotacaoAtual = await _alphaVantageClient.ObterCotacaoAtualAsync(nomeProdutoFinanceiro, cancellationToken);
            return cotacaoAtual > 0 ? cotacaoAtual : null;
        }
    }
}
