using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using XpChallenge.Investimento.Domain.ValueObjects;

namespace XpChallenge.Investimento.Domain.AggregateRoots
{
    public class Operacao(Guid idCliente, TipoOperacao tipo, string nomeProdutoFinanceiro, decimal valor, int quantidade = 1)
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; private set; }

        [BsonElement("IdCliente")]
        public Guid IdCliente { get; private set; } = idCliente;

        [BsonElement("Tipo")]
        public TipoOperacao Tipo { get; private set; } = tipo;

        [BsonElement("Data")]
        public DateTime Data { get; private set; } = DateTime.UtcNow;

        [BsonElement("NomeProdutoFinanceiro")]
        public string NomeProdutoFinanceiro { get; private set; } = nomeProdutoFinanceiro;

        [BsonElement("Quantidade")]
        public int Quantidade { get; private set; } = quantidade;

        [BsonElement("ValorUnitario")]
        public decimal ValorUnitario { get; private set; } = valor;

        [BsonElement("ValorTotal")]
        public decimal ValorTotal { get; private set; } = valor * quantidade;
    }
}
