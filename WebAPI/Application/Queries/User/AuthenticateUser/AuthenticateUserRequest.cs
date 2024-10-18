using MediatR;

namespace Application.Queries.User.AuthenticateUser
{
    public class AuthenticateUserRequest : IRequest<AuthenticateUserResponse>
    {
        public string Email { get; }
        public string Password { get; }

        public AuthenticateUserRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
