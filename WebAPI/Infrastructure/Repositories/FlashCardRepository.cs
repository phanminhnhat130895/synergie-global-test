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
            return await _context.FlashCards.Where(f => f.DateDeleted == null).Skip(request.Page * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);
        }

        public async Task<int> CountFlashCardAsync(CancellationToken cancellationToken)
        {
            return await _context.FlashCards.CountAsync(cancellationToken);
        }
    }
}
