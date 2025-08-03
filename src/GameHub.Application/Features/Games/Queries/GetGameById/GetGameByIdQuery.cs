using GameHub.Application.DTOs;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameById;

public record GetGameByIdQuery (Guid GameId): IRequest<GameDto>;