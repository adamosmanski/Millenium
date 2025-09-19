using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Millenium.API.Models;
using Millenium.Application.Queries;
using Millenium.Data.Interfaces;
using Millenium.Domain;

namespace Millenium.API.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardController : ControllerBase
    {

    private readonly IMediator _mediator;
        private readonly ICardRepository _cardRepository;

        public CardController(IMediator mediator, ICardRepository cardRepository)
        {
            _mediator = mediator;
            _cardRepository = cardRepository;
        }
        [HttpGet("debug/all")]
        public async Task<IActionResult> GetAllCardsDebug()
        {
            var allCards = await _cardRepository.GetAllCardsAsync();
            var result = allCards.Select(card => new
            {
                card.CardNumber,
                CardType = card.CardType.ToString(),
                CardStatus = card.CardStatus.ToString(),
                card.IsPinSet
            });

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCards(string userId)
        {
            try
            {
                var userCards = await _cardRepository.GetUserCardsAsync(userId);
                var result = userCards.Select(card => new CardInfoResponse
                {
                    CardNumber = card.CardNumber,
                    CardType = card.CardType.ToString(),
                    CardStatus = card.CardStatus.ToString(),
                    IsPinSet = card.IsPinSet
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{userId}/{cardNumber}/actions")]
        public async Task<IActionResult> GetActions(string userId, string cardNumber)
        {
            try
            {
                var cardDetails = await _mediator.Send(new GetCardDetailsQuery(userId, cardNumber));

                var actions = await _mediator.Send(new GetAllowedActionsQuery(
                    cardDetails.CardType,
                    cardDetails.CardStatus,
                    cardDetails.IsPinSet));

                return Ok(actions);
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
