using GameHub.Application.DTOs;
using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByAgeRating;

public record GetGameByAgeRatingQuery (AgeRating GameAgeRating) : IRequest<IEnumerable<GameDto>>;