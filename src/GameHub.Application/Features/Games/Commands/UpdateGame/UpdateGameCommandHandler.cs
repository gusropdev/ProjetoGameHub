using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.UpdateGame;

public class UpdateGameCommandHandler (IGameRepository gameRepository, IValidator<UpdateGameCommand> validator, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateGameCommand, Result>
{
    public async Task<Result> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
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
        
        game.UpdateTitle(request.Title);
        game.UpdateDescription(request.Description);
        game.UpdateGenre(request.Genre);
        game.UpdatePlatform(request.Platform);
        game.UpdateDailyRentalPrice(request.DailyRentalPrice);
        game.UpdateReleaseDate(request.ReleaseDate);
        game.UpdateAgeRating(request.AgeRating);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(); // Update successful
    }
}