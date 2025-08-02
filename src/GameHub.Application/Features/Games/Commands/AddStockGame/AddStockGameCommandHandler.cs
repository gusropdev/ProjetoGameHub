using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.AddStockGame;

public class AddStockGameCommandHandler (IGameRepository gameRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<AddStockGameCommand, bool>
{
    public async Task<bool> Handle(AddStockGameCommand request, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetByIdAsync(request.GameId, cancellationToken);
        if (game == null)
        {
            return false; // Game not found
        }
        
        game.AddStock(request.Quantity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return true; // Stock added successfully
    }
}