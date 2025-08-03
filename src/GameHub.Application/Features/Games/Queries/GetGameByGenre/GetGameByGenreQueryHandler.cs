using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByGenre;

public class GetGameByGenreQueryHandler (IGameRepository gameRepository)
    : IRequestHandler<GetGameByGenreQuery, IEnumerable<GameDto>>
{
    public async Task<IEnumerable<GameDto>> Handle(GetGameByGenreQuery request, CancellationToken cancellationToken)
    {
        var games = await gameRepository.GetByGenreAsync(request.GameGenre, cancellationToken);

        return games.Select(game => game.MapToDto());
    }
}