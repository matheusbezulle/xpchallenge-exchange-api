using MongoDB.Bson.Serialization.Attributes;

namespace XpChallenge.Exchange.Domain.ValueObjects
{
    public class ProdutoFinanceiro(string nome, int quantidade, decimal valor)
    {
        [BsonElement("Nome")]
        public string Nome { get; private set; } = nome;

        [BsonElement("Quantidade")]
        public int Quantidade { get; private set; } = quantidade;

        [BsonElement("MediaValor")]
        public decimal MediaValor { get; private set; } = valor;

        public void AdicionarQuantidade(int quantidade, decimal valor)
        {
            decimal valorTotalAnterior = MediaValor * Quantidade;
            decimal valorTotalNovo = valor * quantidade;
            Quantidade += quantidade;
            MediaValor = (valorTotalAnterior + valorTotalNovo) / Quantidade;
        }

        public void DiminuirQuantidade(int quantidade, decimal valor)
        {
            if (Quantidade >= quantidade)
            {
                decimal valorTotalAnterior = MediaValor * Quantidade;
                decimal valorTotalReduzido = valor * quantidade;
                Quantidade -= quantidade;
                MediaValor = (valorTotalAnterior - valorTotalReduzido) / Quantidade;
            }
            else
            {
                throw new Exception("Quantidade insuficiente para diminuir");
            }
        }
    }
}
