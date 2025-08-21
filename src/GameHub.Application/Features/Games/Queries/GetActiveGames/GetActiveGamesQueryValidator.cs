using FluentValidation;

namespace GameHub.Application.Features.Games.Queries.GetActiveGames;
public class GetActiveGamesQueryValidator : AbstractValidator<GetActiveGamesQuery>
{
    public GetActiveGamesQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("Page number must be greater than or equal to 1.");
        RuleFor(x => x.PageSize)
            .InclusiveBetween(5, 50).WithMessage("Page size must be between 5 and 50");
    }
}