using Application.Queries.FlashCards.GetFlashCards;
using Application.Repository;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FlashCardRepository : BaseRepository<FlashCard>, IFlashCardRepository
    {
        public FlashCardRepository(DataContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<FlashCard>> GetFlashCardsAsync(GetFlashCardsRequest request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(request.UserId);
            return await _context.FlashCards.Where(f => f.UserId == userId && f.DateDeleted == null).Skip(request.Page * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);
        }

        public async Task<int> CountFlashCardAsync(GetFlashCardsRequest request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(request.UserId);
            return await _context.FlashCards.CountAsync(f => f.UserId == userId && f.DateDeleted == null, cancellationToken);
        }

        public async Task<bool> CheckFlashCardContentExistingAsync(string content, Guid userId, CancellationToken cancellationToken)
        {
            return await _context.FlashCards.AnyAsync(f => f.UserId == userId && f.Content == content && f.DateDeleted == null, cancellationToken);
        }
    }
}
