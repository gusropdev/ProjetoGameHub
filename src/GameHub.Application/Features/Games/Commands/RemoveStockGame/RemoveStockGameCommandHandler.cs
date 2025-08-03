using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.RemoveStockGame;

public class RemoveStockGameCommandHandler (IGameRepository gameRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveStockGameCommand, bool>
{
    public async Task<bool> Handle(RemoveStockGameCommand request, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetByIdAsync(request.Id, cancellationToken);
        if (game == null)
        {
            return false; // Game not found
        }
        
        game.RemoveStock(request.Quantity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return true; // Stock removed successfully
    }
}