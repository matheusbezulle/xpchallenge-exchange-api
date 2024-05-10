namespace XpChallenge.Exchange.Application.Services.Interfaces
{
    public interface IProdutoFinanceiroService
    {
        Task<decimal?> ObterCotacaoAtualAsync(string nomeProdutoFinanceiro, CancellationToken cancellationToken);
    }
}
