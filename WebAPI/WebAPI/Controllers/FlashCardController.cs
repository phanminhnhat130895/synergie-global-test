using Application.Commands.FlashCards.CreateFlashCard;
using Application.Commands.FlashCards.DeleteFlashCard;
using Application.Common.Helpers;
using Application.Queries.FlashCards.GetFlashCards;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FlashCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlashCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FlashCards([FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            GetFlashCardsRequest request = new GetFlashCardsRequest(page, pageSize, userId);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlashCard([FromBody] CreateFlashCardRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFlashCard([FromQuery] string cardId, CancellationToken cancellationToken)
        {
            DeleteFlashCardRequest request = new DeleteFlashCardRequest(cardId);
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
