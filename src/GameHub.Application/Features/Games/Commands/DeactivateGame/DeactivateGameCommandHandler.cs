using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.DeactivateGame;

public class DeactivateGameCommandHandler (IGameRepository gameRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeactivateGameCommand, bool>
{
    public async Task<bool> Handle(DeactivateGameCommand request, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetByIdAsync(request.GameId, cancellationToken);
        if (game is null)
        {
            return false; // Game not found
        }
        
        game.Deactivate();
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true; // Game successfully deactivated
    }
}