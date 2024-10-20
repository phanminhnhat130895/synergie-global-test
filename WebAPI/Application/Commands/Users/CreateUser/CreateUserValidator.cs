using Application.Common.Helpers;
using FluentValidation;

namespace Application.Commands.Users.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is not provided.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is not provided.")
                .Must(v => PasswordHelper.CheckPasswordStrength(v)).WithMessage("Password must contain at least 8 characters, 1 uppercase, 1 lowercase, 1 number, and 1 special character.");
        }
    }
}
