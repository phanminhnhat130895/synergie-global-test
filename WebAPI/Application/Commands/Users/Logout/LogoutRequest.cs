using MediatR;

namespace Application.Commands.Users.Logout
{
    public class LogoutRequest : IRequest
    {
        public string Token { get; }

        public LogoutRequest(string token)
        {
            Token = token;
        }
    }
}
