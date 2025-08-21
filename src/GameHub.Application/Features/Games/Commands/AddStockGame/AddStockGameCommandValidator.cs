using FluentValidation;

namespace GameHub.Application.Features.Games.Commands.AddStockGame;

public class AddStockGameCommandValidator : AbstractValidator<AddStockGameCommand>
{
    public AddStockGameCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
        
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}