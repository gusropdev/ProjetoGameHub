using FluentValidation;
using GameHub.Application.Common;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Entities;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.CreateGame;

public class CreateGameCommandHandler (IGameRepository gameRepository, IValidator<CreateGameCommand> validator, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateGameCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            
            return Result<Guid>.Failure(errorMessages, ErrorType.Validation);
        }
        
        var game = new Game(
            request.Title,
            request.Description,
            request.DailyRentalPrice,
            request.StockQuantity,
            request.ReleaseDate,
            request.AgeRating,
            request.Genre,
            request.Platform
        );
        
        await gameRepository.AddAsync(game, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result<Guid>.Success(game.Id);
        
    }
}