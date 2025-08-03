using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByPlatform;

public class GetGameByPlatformQueryHandler (IGameRepository gameRepository)
    : IRequestHandler<GetGameByPlatformQuery, IEnumerable<GameDto>>
{
    public async Task<IEnumerable<GameDto>> Handle(GetGameByPlatformQuery request, CancellationToken cancellationToken)
    {
        var games = await gameRepository.GetByPlatformAsync(request.GamePlatform, cancellationToken);

        return games.Select(game => game.MapToDto());
    }
}