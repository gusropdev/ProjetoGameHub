using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.RemoveStockGame;

public class RemoveStockGameCommandHandler (IGameRepository gameRepository, IValidator<RemoveStockGameCommand> validator,IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveStockGameCommand, Result>
{
    public async Task<Result> Handle(RemoveStockGameCommand request, CancellationToken cancellationToken)
    {
        var validationResults = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResults.IsValid)
        {
            var errorMessages = validationResults.Errors
                .Select(error => error.ErrorMessage)
                .ToList();

            return Result.Failure(errorMessages, ErrorType.Validation);
        }
        
        var game = await gameRepository.GetByIdAsync(request.Id, cancellationToken);
        if (game == null)
        {
            return Result.Failure("Game not found.", ErrorType.NotFound);
        }

        try
        {
            game.RemoveStock(request.Quantity);
        }
        catch (InvalidOperationException ex)
        {
            return Result.Failure(ex.Message, ErrorType.Conflict);
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(); // Stock removed successfully
    }
}