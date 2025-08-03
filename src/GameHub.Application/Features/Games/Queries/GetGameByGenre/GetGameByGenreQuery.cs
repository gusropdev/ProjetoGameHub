using GameHub.Application.DTOs;
using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByGenre;

public record GetGameByGenreQuery(Genre GameGenre) : IRequest<IEnumerable<GameDto>>;