using Millenium.Application.Interfaces;
using Millenium.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millenium.Application.Services
{
    public class ActionService : IActionService
    {
        public IEnumerable<string> GetAllowedActions(CardDetails card)
        {
            return (card.CardType, card.CardStatus, card.IsPinSet) switch
            {

                (CardType.Prepaid or CardType.Debit, CardStatus.Ordered, true) => new[] { "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Ordered, false) => new[] { "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Inactive, true) => new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Inactive, false) => new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Active, true) => new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Active, false) => new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Restricted, _) => new[] { "ACTION3", "ACTION4", "ACTION9" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Blocked, true) => new[] { "ACTION3", "ACTION4", "ACTION6", "ACTION7", "ACTION8", "ACTION9" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Blocked, false) => new[] { "ACTION3", "ACTION4", "ACTION8", "ACTION9" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Expired, _) => new[] { "ACTION3", "ACTION4", "ACTION9" },
                (CardType.Prepaid or CardType.Debit, CardStatus.Closed, _) => new[] { "ACTION3", "ACTION4", "ACTION9" },
                (CardType.Credit, CardStatus.Ordered, true) => new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" },
                (CardType.Credit, CardStatus.Ordered, false) => new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" },
                (CardType.Credit, CardStatus.Inactive, true) => new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" },
                (CardType.Credit, CardStatus.Inactive, false) => new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" },
                (CardType.Credit, CardStatus.Active, true) => new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" },
                (CardType.Credit, CardStatus.Active, false) => new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" },
                (CardType.Credit, CardStatus.Restricted, _) => new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" },
                (CardType.Credit, CardStatus.Blocked, true) => new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION7", "ACTION8", "ACTION9" },
                (CardType.Credit, CardStatus.Blocked, false) => new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION8", "ACTION9" },
                (CardType.Credit, CardStatus.Expired, _) => new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" },
                (CardType.Credit, CardStatus.Closed, _) => new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" },
                _ => Array.Empty<string>()
            };
        }
    }
}
