using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using XpChallenge.Exchange.Domain.ValueObjects;

namespace XpChallenge.Exchange.Domain.AggregateRoots
{
    public class Carteira
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; private set; }

        [BsonElement("IdCliente")]
        public Guid IdCliente { get; private set; }

        [BsonElement("ProdutosFinanceiros")]
        public IEnumerable<ProdutosFinanceiros> ProdutosFinanceiros { get; private set; } = [];
    }
}
