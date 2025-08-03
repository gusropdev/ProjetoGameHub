using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByAgeRating;

public class GetGameByAgeRatingQueryHandler (IGameRepository gameRepository)
    : IRequestHandler<GetGameByAgeRatingQuery, IEnumerable<GameDto>>
{
    public async Task<IEnumerable<GameDto>> Handle(GetGameByAgeRatingQuery request, CancellationToken cancellationToken)
    {
        var games = await gameRepository.GetByAgeRatingAsync(request.GameAgeRating, cancellationToken);
        
        return games.Select(game => game.MapToDto());
    }
}