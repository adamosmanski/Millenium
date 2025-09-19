using Millenium.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millenium.Data.Interfaces
{
    public interface ICardRepository
    {
        Task<CardDetails?> GetCardAsync(string userId, string cardNumber);
        Task<IEnumerable<CardDetails>> GetAllCardsAsync();
    }
}
