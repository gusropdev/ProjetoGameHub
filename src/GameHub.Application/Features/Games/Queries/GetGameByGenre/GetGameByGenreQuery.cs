using GameHub.Application.Common.Responses;
using GameHub.Application.DTOs;
using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByGenre;

public record GetGameByGenreQuery(Genre Genre, int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<GameDto>>;