namespace XpChallenge.Investimento.Application.DataTransfer
{
    public class CarteiraDto
    {
        public Guid IdCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ProdutoFinanceiroDto> ProdutosFinanceiros { get; private set; } = [];
    }
}
