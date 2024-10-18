using Application.Repository;
using MediatR;

namespace Application.Queries.FlashCards.GetFlashCards
{
    public class GetFlashCardsHandler : IRequestHandler<GetFlashCardsRequest, GetFlashCardsResponse>
    {
        private readonly IFlashCardRepository _flashCardRepository;

        public GetFlashCardsHandler(IFlashCardRepository flashCardRepository)
        {
            _flashCardRepository = flashCardRepository;
        }

        public async Task<GetFlashCardsResponse> Handle(GetFlashCardsRequest request, CancellationToken cancellationToken)
        {
            var taskCountFlashCard = _flashCardRepository.CountFlashCardAsync(cancellationToken);
            var taskGetFlashCard = _flashCardRepository.GetFlashCardsAsync(request, cancellationToken);

            await Task.WhenAll(taskCountFlashCard, taskGetFlashCard);

            var response = new GetFlashCardsResponse(taskGetFlashCard.Result, taskCountFlashCard.Result);

            return response;
        }
    }
}
