using MediatR;

namespace Application.Queries.FlashCards.GetFlashCards
{
    public class GetFlashCardsRequest : IRequest<GetFlashCardsResponse>
    {
        public int Page { get; }
        public int PageSize { get; }

        public GetFlashCardsRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
