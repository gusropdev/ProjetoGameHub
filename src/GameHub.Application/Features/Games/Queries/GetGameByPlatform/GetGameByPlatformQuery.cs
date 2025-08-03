using GameHub.Application.DTOs;
using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByPlatform;

public record GetGameByPlatformQuery (Platform GamePlatform) : IRequest<IEnumerable<GameDto>>;