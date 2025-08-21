using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.ActivateGame;

public class ActivateGameCommandHandler (IGameRepository gameRepository, IValidator<ActivateGameCommand> validator, IUnitOfWork unitOfWork) 
    : IRequestHandler<ActivateGameCommand, Result>
{
    public async Task<Result> Handle(ActivateGameCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(error => error.ErrorMessage)
                .ToList();

            return Result.Failure(errorMessages, ErrorType.Validation);
        }
        
        var game = await gameRepository.GetByIdAsync(request.Id, cancellationToken);
        if (game == null)
        {
            return Result.Failure("Game not found.", ErrorType.NotFound); // Game not found
        }

        try
        {
            game.Activate();
        }
        catch (InvalidOperationException ex)
        {
            return Result.Failure(ex.Message, ErrorType.Conflict);
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(); // Game activated successfully
    }
}