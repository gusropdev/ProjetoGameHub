using FluentValidation;

namespace GameHub.Application.Features.Games.Queries.GetGameById;

public class GetGameByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
{
    public GetGameByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Game ID cannot be empty.");
    }
}