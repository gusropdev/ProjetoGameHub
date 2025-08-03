using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetActiveGames;

public class GetActiveGamesQueryHandler (IGameRepository gameRepository)
    : IRequestHandler<GetActiveGamesQuery, IEnumerable<GameDto>>
{
    public async Task<IEnumerable<GameDto>> Handle(GetActiveGamesQuery request, CancellationToken cancellationToken)
    {
        var games = await gameRepository.GetActiveAsync(cancellationToken);

        return games.Select(game => game.MapToDto());
        
    }
}