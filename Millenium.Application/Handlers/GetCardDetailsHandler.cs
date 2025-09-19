using MediatR;
using Millenium.Application.Queries;
using Millenium.Data.Interfaces;
using Millenium.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millenium.Application.Handlers
{
    public class GetCardDetailsHandler : IRequestHandler<GetCardDetailsQuery, CardDetails>
    {
        private readonly ICardRepository _cardRepository;

        public GetCardDetailsHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardDetails> Handle(GetCardDetailsQuery request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetCardAsync(request.UserId, request.CardNumber);

            if (card == null)
                throw new Exception($"Card {request.CardNumber} for user {request.UserId} not found");

            return card;
        }
    }
}
