using Refit;
using XpChallenge.Investimento.Infra.External.Responses;

namespace XpChallenge.Investimento.Infra.External.Apis
{
    public interface IAlphaVantageApi
    {
        [Get("/query?function=GLOBAL_QUOTE&symbol&apikey")]
        Task<CotacoesResponse> ObterCotacoesAsync([Query][AliasAs("symbol")] string nomeProdutoFinanceiro, [Query][AliasAs("apikey")] string apiKey, CancellationToken cancellationToken);
    }
}
