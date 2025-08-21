using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.AddStockGame;

public class AddStockGameCommandHandler (IGameRepository gameRepository, IValidator<AddStockGameCommand> validator,IUnitOfWork unitOfWork)
    : IRequestHandler<AddStockGameCommand, Result>
{
    public async Task<Result> Handle(AddStockGameCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(x => x.ErrorMessage)
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
            game.AddStock(request.Quantity);
        }
        catch (InvalidOperationException ex)
        {
            return Result.Failure(ex.Message, ErrorType.Conflict);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(); // Stock added successfully
    }
}