using FluentValidation;

namespace GameHub.Application.Features.Games.Commands.UpdateGame;

public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
{
    public UpdateGameCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        
        RuleFor(x => x.ReleaseDate)
            .NotEmpty().WithMessage("Release date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Release date cannot be in the future.");

        RuleFor(x => x.DailyRentalPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Daily rental price must be zero or greater.");
        
        RuleFor(x => x.AgeRating)
            .IsInEnum().WithMessage("Invalid age rating specified.");
        
        RuleFor(x => x.Genre)
            .IsInEnum().WithMessage("Invalid genre specified.");
        
        RuleFor(x => x.Platform)
            .IsInEnum().WithMessage("Invalid platform specified.");

    }
}