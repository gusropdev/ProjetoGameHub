using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetAllGames;

public class GetAllGamesQueryHandler (IGameRepository gameRepository) : IRequestHandler<GetAllGamesQuery, IEnumerable<GameDto>>
{
    public async Task<IEnumerable<GameDto>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        var games = await gameRepository.GetAllAsync(cancellationToken);
        return games.Select(game => game.MapToDto());
    }
}