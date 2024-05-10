using System.Text.Json.Serialization;

namespace XpChallenge.Exchange.Infra.External.Responses
{
    public class CotacoesResponse
    {
        [JsonPropertyName("Global Quote")]
        public CotacaoGlobalResponse CotacaoGlobal { get; set; }
    }
}
