using FluentValidation;

namespace GameHub.Application.Features.Games.Commands.RemoveStockGame;

public class RemoveStockGameCommandValidator : AbstractValidator<RemoveStockGameCommand>
{
    public RemoveStockGameCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
        
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}