using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameByAgeRating;

public class GetGameByAgeRatingQueryHandler (IGameRepository gameRepository, IValidator<GetGameByAgeRatingQuery> validator)
    : IRequestHandler<GetGameByAgeRatingQuery, PagedResult<GameDto>>
{
    public async Task<PagedResult<GameDto>> Handle(GetGameByAgeRatingQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            
            return PagedResult<GameDto>.Failure(errorMessages, ErrorType.Validation);
        }
        
        var games = await gameRepository.GetByAgeRatingAsync(request.AgeRating, cancellationToken);
        var totalCount = games.Count;
        
        if (totalCount == 0)
        {
            return PagedResult<GameDto>.Failure("No games found for the specified age rating.", ErrorType.NotFound);
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