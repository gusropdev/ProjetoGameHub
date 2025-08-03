using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameById;

public class GetGameByIdQueryHandler (IGameRepository gameRepository) : IRequestHandler<GetGameByIdQuery, GameDto>
{
    public async Task<GameDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetByIdAsync(request.GameId, cancellationToken);
        if (game == null)
        {
            throw new KeyNotFoundException($"Game with ID {request.GameId} not found.");
        }

        return game.MapToDto();

    }
}