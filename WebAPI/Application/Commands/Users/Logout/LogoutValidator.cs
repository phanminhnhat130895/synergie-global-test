using FluentValidation;

namespace Application.Commands.Users.Logout
{
    public class LogoutValidator : AbstractValidator<LogoutRequest>
    {
        public LogoutValidator() 
        { 
            RuleFor(x => x.Token).NotEmpty().WithMessage("Token is not provided.");
        }
    }
}
