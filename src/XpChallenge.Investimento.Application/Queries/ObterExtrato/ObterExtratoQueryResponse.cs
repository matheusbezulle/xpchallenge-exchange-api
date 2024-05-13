using XpChallenge.Investimento.Application.DataTransfer;

namespace XpChallenge.Investimento.Application.Queries.ObterExtrato
{
    public class ObterExtratoQueryResponse : ResponseBaseDto
    {
        public List<RegistroOperacaoDto> Registros { get; set; } = [];
    }
}