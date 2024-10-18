using MediatR;

namespace Application.Commands.FlashCards.DeleteFlashCard
{
    public class DeleteFlashCardRequest : IRequest<DeleteFlashCardResponse>
    {
        public string CardId { get; }

        public DeleteFlashCardRequest(string cardId)
        {
            CardId = cardId;
        }
    }
}
