using MediatR;

namespace Application.Commands.Users.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Email { get; }
        public string Password { get; }

        public CreateUserRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
