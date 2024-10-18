using MediatR;

namespace Application.Commands.FlashCards.CreateFlashCard
{
    public class CreateFlashCardRequest : IRequest<CreateFlashCardResponse>
    {
        public string Content { get; }
        public string Meaning { get; }

        public CreateFlashCardRequest(string content, string meaning) 
        { 
            Content = content;
            Meaning = meaning;
        }
    }
}
