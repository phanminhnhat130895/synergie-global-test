using MediatR;

namespace Application.Queries.FlashCards.GetFlashCards
{
    public class GetFlashCardsRequest : IRequest<GetFlashCardsResponse>
    {
        public int Page { get; }
        public int PageSize { get; }
        public string UserId { get; }

        public GetFlashCardsRequest(int page, int pageSize, string userId)
        {
            Page = page;
            PageSize = pageSize;
            UserId = userId;
        }
    }
}
