using Application.Repository;
using Core.Entities;
using MediatR;

namespace Application.Commands.FlashCards.CreateFlashCard
{
    public class CreateFlashCardHandler : IRequestHandler<CreateFlashCardRequest, CreateFlashCardResponse>
    {
        private readonly IFlashCardRepository _flashCardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFlashCardHandler(IFlashCardRepository flashCardRepository, IUnitOfWork unitOfWork)
        {
            _flashCardRepository = flashCardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateFlashCardResponse> Handle(CreateFlashCardRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var guidUserId = Guid.Parse(request.UserId);

            await CheckFlashCardExisting(request.Content, guidUserId, cancellationToken);

            var flashCard = new FlashCard(Guid.NewGuid()).SetContent(request.Content).SetMeaning(request.Meaning).SetUserId(guidUserId);

            var data = await _flashCardRepository.CreateAsync(flashCard, cancellationToken);

            await _unitOfWork.SaveAsync(cancellationToken);

            return new CreateFlashCardResponse(data.Entity);
        }

        private async Task CheckFlashCardExisting(string content, Guid userId, CancellationToken cancellationToken)
        {
            var isExistingFlashCard = await _flashCardRepository.CheckFlashCardContentExistingAsync(content, userId, cancellationToken);
            if (isExistingFlashCard)
            {
                throw new Exception($"Flash Card With Content {content} Has Been Existing.");
            }
        }
    }
}
