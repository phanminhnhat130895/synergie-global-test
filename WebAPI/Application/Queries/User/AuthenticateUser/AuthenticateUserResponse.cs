namespace Application.Queries.User.AuthenticateUser
{
    public class AuthenticateUserResponse
    {
        public string AccessToken { get; }

        public AuthenticateUserResponse(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
