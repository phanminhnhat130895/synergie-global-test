using FluentValidation;

namespace Application.Commands.FlashCards.CreateFlashCard
{
    public class CreateFlashCardValidatior : AbstractValidator<CreateFlashCardRequest>
    {
        public CreateFlashCardValidatior()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is not provided.");

            RuleFor(x => x.Meaning).NotEmpty().WithMessage("Meaning is not provided.");
        }
    }
}
