using MediatR;
using Millenium.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millenium.Application.Queries
{
    public record GetAllowedActionsQuery(CardType CardType, CardStatus CardStatus, bool IsPinSet)
        : IRequest<IEnumerable<string>>;
}
