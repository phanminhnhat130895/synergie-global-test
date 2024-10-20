using Application.Queries.FlashCards.GetFlashCards;
using Core.Entities;

namespace Application.Repository
{
    public interface IFlashCardRepository : IBaseRepository<FlashCard>
    {
        Task<IReadOnlyCollection<FlashCard>> GetFlashCardsAsync(GetFlashCardsRequest request, CancellationToken cancellationToken);
        Task<int> CountFlashCardAsync(GetFlashCardsRequest request, CancellationToken cancellationToken);
        Task<bool> CheckFlashCardContentExistingAsync(string content, Guid userId, CancellationToken cancellationToken);
    }
}
