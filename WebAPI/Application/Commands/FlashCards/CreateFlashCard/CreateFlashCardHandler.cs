using Application.Repository;
using Core.Entities;
using MediatR;

namespace Application.Commands.FlashCards.CreateFlashCard
{
    public class CreateFlashCardHandler : IRequestHandler<CreateFlashCardRequest, CreateFlashCardResponse>
    {
        private readonly IFlashCardRepository _flashCardRepository;

        public CreateFlashCardHandler(IFlashCardRepository flashCardRepository)
        {
            _flashCardRepository = flashCardRepository;
        }

        public async Task<CreateFlashCardResponse> Handle(CreateFlashCardRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var flashCard = new FlashCard(Guid.NewGuid()).SetContent(request.Content).SetMeaning(request.Meaning);

            var data = await _flashCardRepository.CreateAsync(flashCard, cancellationToken);

            return new CreateFlashCardResponse(data.Entity);
        }
    }
}
