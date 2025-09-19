using Millenium.View.Models;
using System.Dynamic;

namespace Millenium.View.Interface
{
    public interface IActionService
    {
        Task<List<string>> GetCardActionsAsync(string userId, string cardNumber);
        Task<List<CardInfo>> GetUserCardsAsync(string userId);
    }

}
