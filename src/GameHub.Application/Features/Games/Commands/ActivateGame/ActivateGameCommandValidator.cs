using FluentValidation;

namespace GameHub.Application.Features.Games.Commands.ActivateGame;

public class ActivateGameCommandValidator : AbstractValidator<ActivateGameCommand>
{
    public ActivateGameCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}