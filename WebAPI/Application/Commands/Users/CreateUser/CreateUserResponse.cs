namespace Application.Commands.Users.CreateUser
{
    public class CreateUserResponse
    {
        public bool Success { get; }
        
        public CreateUserResponse(bool success)
        {
            Success = success;
        }
    }
}
