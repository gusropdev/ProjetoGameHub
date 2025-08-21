using GameHub.Application.Common.Responses;
using GameHub.Application.DTOs;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameById;

public record GetGameByIdQuery (Guid Id): IRequest<Result<GameDto>>;