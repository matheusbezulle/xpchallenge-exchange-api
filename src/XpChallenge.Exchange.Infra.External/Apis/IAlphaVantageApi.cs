using Refit;
using XpChallenge.Exchange.Infra.External.Responses;

namespace XpChallenge.Exchange.Infra.External.Apis
{
    public interface IAlphaVantageApi
    {
        [Get("/query?function=GLOBAL_QUOTE&symbol&apikey")]
        Task<CotacoesResponse> ObterCotacoesAsync([Query][AliasAs("symbol")] string nomeProdutoFinanceiro, [Query][AliasAs("apikey")] string apiKey, CancellationToken cancellationToken);
    }
}
