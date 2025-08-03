using GameHub.Application.DTOs;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetActiveGames;

public class GetActiveGamesQuery : IRequest<IEnumerable<GameDto>>
{
    
}