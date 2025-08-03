using GameHub.Application.DTOs;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetInactiveGames;

public class GetInactiveGamesQuery : IRequest<IEnumerable<GameDto>>
{
    
}