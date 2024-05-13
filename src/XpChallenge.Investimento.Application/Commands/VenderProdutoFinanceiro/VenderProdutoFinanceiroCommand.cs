using MediatR;

namespace XpChallenge.Investimento.Application.Commands.VenderProdutoFinanceiro
{
    public class VenderProdutoFinanceiroCommand(Guid idCliente, string nome, int quantidade) : IRequest<VenderProdutoFinanceiroCommandResponse>
    {
        public Guid IdCliente { get; set; } = idCliente;
        public string NomeProdutoFinanceiro { get; set; } = nome;
        public int Quantidade { get; set; } = quantidade;
    }
}
