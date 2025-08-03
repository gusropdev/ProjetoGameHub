using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.ActivateGame;

public class ActivateGameCommandHandler (IGameRepository gameRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<ActivateGameCommand, bool>
{
    public async Task<bool> Handle(ActivateGameCommand request, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetByIdAsync(request.Id, cancellationToken);
        if (game == null)
        {
            return false; // Game not found
        }
        
        game.Activate();
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true; // Game activated successfully
    }
}