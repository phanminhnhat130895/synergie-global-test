using Core.Entities;

namespace Application.Queries.FlashCards.GetFlashCards
{
    public class GetFlashCardsResponse
    {
        public IReadOnlyCollection<FlashCard> FlashCards { get; }
        public int FlashCardCount { get; }

        public GetFlashCardsResponse(IReadOnlyCollection<FlashCard> flashCards, int flashCardCount)
        {
            FlashCards = flashCards;
            FlashCardCount = flashCardCount;
        }
    }
}
