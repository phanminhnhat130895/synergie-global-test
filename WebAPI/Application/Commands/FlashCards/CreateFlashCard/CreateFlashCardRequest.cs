using MediatR;

namespace Application.Commands.FlashCards.CreateFlashCard
{
    public class CreateFlashCardRequest : IRequest<CreateFlashCardResponse>
    {
        public string Content { get; }
        public string Meaning { get; }
        public string UserId { get; private set; }

        public CreateFlashCardRequest(string content, string meaning, string userId) 
        { 
            Content = content;
            Meaning = meaning;
            UserId = userId;
        }
    }
}
