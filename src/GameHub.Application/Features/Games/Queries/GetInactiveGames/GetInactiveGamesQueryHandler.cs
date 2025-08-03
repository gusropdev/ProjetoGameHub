using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetInactiveGames;

public class GetInactiveGamesQueryHandler (IGameRepository gameRepository)
    : IRequestHandler<GetInactiveGamesQuery, IEnumerable<GameDto>>
{
    public async Task<IEnumerable<GameDto>> Handle(GetInactiveGamesQuery request, CancellationToken cancellationToken)
    {
        var games = await gameRepository.GetInactiveAsync(cancellationToken);

        return games.Select(game => game.MapToDto());
    }
}