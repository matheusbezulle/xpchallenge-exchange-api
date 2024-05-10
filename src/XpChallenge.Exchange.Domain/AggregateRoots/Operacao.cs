using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using XpChallenge.Exchange.Domain.ValueObjects;

namespace XpChallenge.Exchange.Domain.AggregateRoots
{
    public class Operacao
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; private set; }
        
        [BsonElement("IdCliente")]
        public Guid IdCliente { get; private set; }

        [BsonElement("Tipo")]
        public TipoOperacao Tipo { get; private set; }

        [BsonElement("Data")]
        public DateTime Data { get; private set; }

        [BsonElement("NomeProdutoFinanceiro")]
        public string NomeProdutoFinanceiro { get; private set; } = string.Empty;

        [BsonElement("Quantidade")]
        public int Quantidade { get; private set; }

        [BsonElement("ValorUnitario")]
        public decimal ValorUnitario { get; private set; }

        [BsonElement("ValorTotal")]
        public decimal ValorTotal { get; private set; }
    }
}
