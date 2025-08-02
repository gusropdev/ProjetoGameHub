using GameHub.Application.DTOs;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetAllGames;

public class GetAllGamesQuery : IRequest<IEnumerable<GameDto>>
{
    
}