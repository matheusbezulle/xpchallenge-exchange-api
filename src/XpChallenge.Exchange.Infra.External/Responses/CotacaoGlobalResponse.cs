using System.Text.Json.Serialization;

namespace XpChallenge.Exchange.Infra.External.Responses
{
    public class CotacaoGlobalResponse
    {
        [JsonPropertyName("05. price")]
        public string CotacaoAtual { get; set; }
    }
}