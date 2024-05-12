using XpChallenge.Exchange.Application.DataTransfer;

namespace XpChallenge.Exchange.Application.Queries.ObterCarteira
{
    public class ObterCarteiraQueryResponse : ResponseBaseDto
    {
        public CarteiraDto? Carteira { get; set; }
    }
}