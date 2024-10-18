using Application.Repository;
using MediatR;

namespace Application.Commands.FlashCards.DeleteFlashCard
{
    public class DeleteFlashCardHandler : IRequestHandler<DeleteFlashCardRequest, DeleteFlashCardResponse>
    {
        private readonly IFlashCardRepository _flashCardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFlashCardHandler(IFlashCardRepository flashCardRepository, IUnitOfWork unitOfWork)
        {
            _flashCardRepository = flashCardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteFlashCardResponse> Handle(DeleteFlashCardRequest request, CancellationToken cancellationToken)
        {
            var flashCard = await _flashCardRepository.GetAsync(Guid.Parse(request.CardId), cancellationToken);

            if (flashCard == null)
            {
                throw new Exception("FlashCard not found.");
            }

            _flashCardRepository.SoftDelete(flashCard);

            await _unitOfWork.SaveAsync(cancellationToken);

            return new DeleteFlashCardResponse(flashCard.Id.ToString());
        }
    }
}
