using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetAllGames;

public class GetAllGamesQueryHandler (IGameRepository gameRepository, IValidator<GetAllGamesQuery> validator) 
    : IRequestHandler<GetAllGamesQuery, PagedResult<GameDto>>
{
    public async Task<PagedResult<GameDto>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            return PagedResult<GameDto>.Failure(errorMessages, ErrorType.Validation);
        }
        
        var games = await gameRepository.GetAllAsync(cancellationToken);
        
        var totalCount = games.Count;
        
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