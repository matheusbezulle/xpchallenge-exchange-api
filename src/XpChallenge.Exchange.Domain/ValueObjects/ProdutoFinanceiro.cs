using MongoDB.Bson.Serialization.Attributes;

namespace XpChallenge.Exchange.Domain.ValueObjects
{
    public class ProdutoFinanceiro(string nome, int quantidade, decimal valor)
    {
        [BsonElement("Nome")]
        public string Nome { get; private set; } = nome;

        [BsonElement("Quantidade")]
        public int Quantidade { get; private set; } = quantidade;

        [BsonElement("ValorMedia")]
        public decimal ValorMedia { get; private set; } = valor;

        public void AdicionarQuantidade(int quantidade, decimal valor)
        {
            decimal valorTotalAnterior = ValorMedia * Quantidade;
            decimal valorTotalNovo = valor * quantidade;
            Quantidade += quantidade;
            ValorMedia = (valorTotalAnterior + valorTotalNovo) / Quantidade;
        }

        public void DiminuirQuantidade(int quantidade, decimal valor)
        {
            if (Quantidade >= quantidade)
            {
                decimal valorTotalAnterior = ValorMedia * Quantidade;
                decimal valorTotalReduzido = valor * quantidade;
                Quantidade -= quantidade;
                ValorMedia = (valorTotalAnterior - valorTotalReduzido) / Quantidade;
            }
            else
            {
                throw new Exception("Quantidade insuficiente para diminuir");
            }
        }
    }
}
