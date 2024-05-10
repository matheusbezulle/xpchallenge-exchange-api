using XpChallenge.Exchange.Application.DataTransfer;

namespace XpChallenge.Exchange.Application.Queries.ObterExtrato
{
    public class ObterExtratoQueryResponse : ResponseBaseDto
    {
        public List<RegistroOperacaoDto> Registros { get; set; } = [];
    }
}