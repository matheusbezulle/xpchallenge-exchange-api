using XpChallenge.Investimento.Application.DataTransfer;

namespace XpChallenge.Investimento.Application.Queries.ObterCarteira
{
    public class ObterCarteiraQueryResponse : ResponseBaseDto
    {
        public CarteiraDto? Carteira { get; set; }
    }
}