using Core.Entities;

namespace Application.Commands.FlashCards.CreateFlashCard
{
    public class CreateFlashCardResponse
    {
        public FlashCard FlashCard { get; }

        public CreateFlashCardResponse(FlashCard flashCard)
        {
            FlashCard = flashCard;
        }
    }
}
