using FluentValidation;

namespace Application.Queries.FlashCards.GetFlashCards
{
    public class GetFlashCardsValidator : AbstractValidator<GetFlashCardsRequest>
    {
        public GetFlashCardsValidator() 
        {
            RuleFor(x => x.Page).Must(v => v >= 0).WithMessage("Invalid page.");

            RuleFor(x => x.PageSize).Must(v => v >= 0).WithMessage("Invalid page size.");
        }
    }
}
