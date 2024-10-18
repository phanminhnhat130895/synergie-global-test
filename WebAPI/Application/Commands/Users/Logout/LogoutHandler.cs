using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Commands.Users.Logout
{
    public class LogoutHandler : IRequestHandler<LogoutRequest>
    {
        private readonly IMemoryCache _memoryCache;

        public LogoutHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            _memoryCache.Set(request.Token, true, TimeSpan.FromHours(8));
        }
    }
}
