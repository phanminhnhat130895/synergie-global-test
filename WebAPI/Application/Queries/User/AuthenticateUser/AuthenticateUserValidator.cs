using FluentValidation;

namespace Application.Queries.User.AuthenticateUser
{
    public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserRequest>
    {
        public AuthenticateUserValidator() 
        { 
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is not provided.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is not provided.");
        }
    }
}
