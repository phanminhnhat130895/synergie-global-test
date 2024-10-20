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
            var countFlashCard = await _flashCardRepository.CountFlashCardAsync(request, cancellationToken);
            var flashCards = await _flashCardRepository.GetFlashCardsAsync(request, cancellationToken);
            flashCards = flashCards.OrderBy(f => f.DateCreated).ToList();

            var response = new GetFlashCardsResponse(flashCards, countFlashCard);

            return response;
        }
    }
}
