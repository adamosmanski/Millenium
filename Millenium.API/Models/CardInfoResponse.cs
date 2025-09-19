namespace Millenium.API.Models
{
    public class CardInfoResponse
    {
        public string CardNumber { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string CardStatus { get; set; } = string.Empty;
        public bool IsPinSet { get; set; }
    }
}
