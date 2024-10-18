using Application.Common.Helpers;
using FluentValidation;

namespace Application.Commands.FlashCards.DeleteFlashCard
{
    public class DeleteFlashCardValidator : AbstractValidator<DeleteFlashCardRequest>
    {
        public DeleteFlashCardValidator() 
        { 
            RuleFor(x => x.CardId).NotEmpty().WithMessage("CardId is not provided.")
                                  .Must(v => GuidHelper.BeAValidGuid(v)).WithMessage("Invalid card id.");
        }
    }
}
