using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.DeleteGame;

public class DeleteGameCommandHandler (IGameRepository gameRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteGameCommand, bool>
{
    public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetByIdAsync(request.Id, cancellationToken);
        if (game == null)
        {
            return false; // Game not found
        }
        
        gameRepository.Delete(game, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return true; // Deletion successful
    }
}