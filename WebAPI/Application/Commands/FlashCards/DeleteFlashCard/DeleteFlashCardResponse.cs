namespace Application.Commands.FlashCards.DeleteFlashCard
{
    public class DeleteFlashCardResponse
    {
        public string CardId { get; }

        public DeleteFlashCardResponse(string cardId)
        {
            CardId = cardId;
        }
    }
}
