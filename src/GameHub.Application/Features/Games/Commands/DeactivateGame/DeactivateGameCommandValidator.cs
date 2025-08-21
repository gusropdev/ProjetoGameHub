using FluentValidation;

namespace GameHub.Application.Features.Games.Commands.DeactivateGame;

public class DeactivateGameCommandValidator : AbstractValidator<DeactivateGameCommand>
{
    public DeactivateGameCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Game ID is required.");
    }
}