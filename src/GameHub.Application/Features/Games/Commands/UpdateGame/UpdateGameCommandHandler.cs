using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.UpdateGame;

public class UpdateGameCommandHandler (IGameRepository gameRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<UpdateGameCommand, bool>
{
    public async Task<bool> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetByIdAsync(request.Id, cancellationToken);
        if (game == null)
        {
            return false; // Game not found
        }
        
        game.UpdateTitle(request.Title);
        game.UpdateDescription(request.Description);
        game.UpdateGenre(request.Genre);
        game.UpdatePlatform(request.Platform);
        game.UpdateDailyRentalPrice(request.DailyRentalPrice);
        game.UpdateReleaseDate(request.ReleaseDate);
        game.UpdateAgeRating(request.AgeRating);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return true; // Update successful
    }
}