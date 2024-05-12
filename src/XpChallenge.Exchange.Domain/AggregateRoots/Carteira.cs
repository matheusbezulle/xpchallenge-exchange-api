using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using XpChallenge.Exchange.Domain.ValueObjects;

namespace XpChallenge.Exchange.Domain.AggregateRoots
{
    public class Carteira(Guid idCliente)
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; private set; }

        [BsonElement("IdCliente")]
        public Guid IdCliente { get; private set; } = idCliente;

        [BsonElement("ProdutosFinanceiros")]
        public List<ProdutoFinanceiro> ProdutosFinanceiros { get; private set; } = [];

        public void AdicionarProdutoFinanceiro(string nomeProdutoFinanceiro, int quantidade, decimal valor)
        {
            var produtoFinanceiro = ObterProdutoFinanceiro(nomeProdutoFinanceiro);

            if (produtoFinanceiro == null)
                ProdutosFinanceiros.Add(new(nomeProdutoFinanceiro, quantidade, valor));
            else
                produtoFinanceiro.AdicionarQuantidade(quantidade, valor);
        }

        public ProdutoFinanceiro? ObterProdutoFinanceiro(string nomeProdutoFinanceiro)
        {
            return ProdutosFinanceiros.FirstOrDefault(p => p.Nome.Equals(nomeProdutoFinanceiro));
        }

        public bool PossuiProdutosFinanceiros()
        {
            return ProdutosFinanceiros.Count > 0;
        }
    }
}
