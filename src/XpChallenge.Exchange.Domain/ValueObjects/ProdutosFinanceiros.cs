using MongoDB.Bson.Serialization.Attributes;

namespace XpChallenge.Exchange.Domain.ValueObjects
{
    public class ProdutosFinanceiros
    {
        [BsonElement("Nome")]
        public string Nome { get; private set; } = string.Empty;

        [BsonElement("Quantidade")]
        public int Quantidade { get; private set; }

        [BsonElement("MediaValor")]
        public decimal MediaValor { get; private set; }
    }
}
