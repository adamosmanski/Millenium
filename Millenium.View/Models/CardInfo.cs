using System.Text.Json.Serialization;

namespace Millenium.View.Models
{
    public class CardInfo
    {
        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; } = string.Empty;

        [JsonPropertyName("cardType")]
        public string CardType { get; set; } = string.Empty;

        [JsonPropertyName("cardStatus")]
        public string CardStatus { get; set; } = string.Empty;

        [JsonPropertyName("isPinSet")]
        public bool IsPinSet { get; set; }
    }
}
