namespace XpChallenge.Investimento.Application.DataTransfer
{
    public class RegistroOperacaoDto
    {
        public string TipoOperacao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
