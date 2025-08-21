using GameHub.Application.Common.Responses;
using GameHub.Application.DTOs;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetInactiveGames;

public record GetInactiveGamesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<GameDto>>;