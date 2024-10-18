using Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Application.Security
{
    public interface IJwtHandler
    {
        string Create(User user);
        TokenValidationParameters Parameters { get; }
    }
}
