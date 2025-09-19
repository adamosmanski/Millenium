using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Millenium.Application.Queries;
using Millenium.Domain;

namespace Millenium.API.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator) => _mediator = mediator;

        [HttpGet("actions")]
        public async Task<IActionResult> GetActions([FromQuery] CardType type, [FromQuery] CardStatus status, [FromQuery] bool isPinSet)
        {
            var actions = await _mediator.Send(new GetAllowedActionsQuery(type, status, isPinSet));
            return Ok(actions);
        }
    }
}
