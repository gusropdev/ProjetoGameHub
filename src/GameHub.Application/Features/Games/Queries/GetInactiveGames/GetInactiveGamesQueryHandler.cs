using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetInactiveGames;

public class GetInactiveGamesQueryHandler (IGameRepository gameRepository, IValidator<GetInactiveGamesQuery> validator)
    : IRequestHandler<GetInactiveGamesQuery, PagedResult<GameDto>>
{
    public async Task<PagedResult<GameDto>> Handle(GetInactiveGamesQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            return PagedResult<GameDto>.Failure(errorMessages);
        }
        
        var games = await gameRepository.GetInactiveAsync(cancellationToken);

        var totalCount = games.Count;
        
        var pagedGames = games
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(game => game.MapToDto())
            .ToList();

        return PagedResult<GameDto>.Success(
            pagedGames,
            totalCount,
            request.PageNumber,
            request.PageSize);
    }
}