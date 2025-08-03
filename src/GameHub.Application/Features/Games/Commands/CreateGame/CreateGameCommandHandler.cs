using GameHub.Application.Mapping;
using GameHub.Domain.Entities;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.CreateGame;

public class CreateGameCommandHandler (IGameRepository gameRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateGameCommand, Guid>
{
    public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = new Game(
            request.Title,
            request.Description,
            request.DailyRentalPrice,
            request.StockQuantity,
            request.ReleaseDate,
            request.AgeRating,
            request.Genre,
            request.Platform
        );
        
        await gameRepository.AddAsync(game, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return game.Id;
    }
}