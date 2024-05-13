using System.ComponentModel.DataAnnotations;

namespace XpChallenge.Investimento.Api.Requests
{
    public class ComprarProdutoFinanceiroRequest
    {
        [Required(ErrorMessage = "O campo 'IdCliente' é obrigatório.")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O campo 'NomeProdutoFinanceiro' é obrigatório.")]
        public string NomeProdutoFinanceiro { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo 'Quantidade' deve ser maior que 0.")]
        public int Quantidade { get; set; }
    }
}
