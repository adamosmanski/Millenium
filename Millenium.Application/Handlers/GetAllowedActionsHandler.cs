using MediatR;
using Millenium.Application.Interfaces;
using Millenium.Application.Queries;
using Millenium.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millenium.Application.Handlers
{
    public class GetAllowedActionsHandler : IRequestHandler<GetAllowedActionsQuery, IEnumerable<string>>
    {
        private readonly IActionService _actionService;

        public GetAllowedActionsHandler(IActionService actionService)
        {
            _actionService = actionService;
        }

        public Task<IEnumerable<string>> Handle(GetAllowedActionsQuery request, CancellationToken cancellationToken)
        {
            var card = new CardDetails("Virtual", request.CardType, request.CardStatus, request.IsPinSet);
            var actions = _actionService.GetAllowedActions(card);
            return Task.FromResult(actions);
        }
    }
}
