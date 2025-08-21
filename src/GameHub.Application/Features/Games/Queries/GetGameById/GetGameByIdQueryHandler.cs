using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Application.DTOs;
using GameHub.Application.Mapping;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Queries.GetGameById;

public class GetGameByIdQueryHandler (IGameRepository gameRepository, IValidator<GetGameByIdQuery> validator)
    : IRequestHandler<GetGameByIdQuery, Result<GameDto>>
{
    public async Task<Result<GameDto>> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            
            return Result<GameDto>.Failure(errorMessages, ErrorType.Validation);
        }
        
        var game = await gameRepository.GetByIdAsync(request.Id, cancellationToken);
        if (game == null)
        {
            return Result<GameDto>.Failure("Game not found", ErrorType.NotFound);
        }
        return Result<GameDto>.Success(game.MapToDto());
    }
}