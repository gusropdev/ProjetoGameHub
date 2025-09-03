using FluentValidation;

namespace GameHub.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("The full name must be at least 3 characters long.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("The email address is not valid.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8).WithMessage("The password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("The password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("The password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("The password must contain at least one number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("The password must contain at least one special character.");
    }
}