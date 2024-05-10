namespace XpChallenge.Exchange.Infra.External.Clients.Interfaces
{
    public interface IAlphaVantageClient
    {
        Task<decimal> ObterCotacaoAtualAsync(string nomeProdutoFinanceiro, CancellationToken cancellationToken);
    }
}
