using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByGenre;

public class GetGameByGenreQueryHandler (IGameRepository gameRepository, IValidator<GetGameByGenreQuery> validator)
    : IRequestHandler<GetGameByGenreQuery, PagedResult<GameDto>>
{
    public async Task<PagedResult<GameDto>> Handle(GetGameByGenreQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            
            return PagedResult<GameDto>.Failure(errorMessages, ErrorType.Validation);
        }
        
        var games = await gameRepository.GetByGenreAsync(request.GenreId, cancellationToken);
        var totalCount = games.Count;
        
        if (totalCount == 0)
        {
            return PagedResult<GameDto>.Failure("No games found for the specified genre.", ErrorType.NotFound);
        }

        var pagedGames = games
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(g => g.MapToDto())
            .ToList();
        
        return PagedResult<GameDto>.Success(
            pagedGames,
            totalCount,
            request.PageNumber,
            request.PageSize);
    }
}