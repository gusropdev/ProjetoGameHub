using FluentValidation;
using GameHub.Application.Common;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Entities;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.CreateGame;

public class CreateGameCommandHandler (IGameRepository gameRepository,
    IGenreRepository genreRepository,
    IPlatformRepository platformRepository,
    IValidator<CreateGameCommand> validator,
    IUnitOfWork unitOfWork) 
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
        
        var genres = await genreRepository.GetByIdsAsync(request.GenreIds, cancellationToken);
        var platforms = await platformRepository.GetByIdsAsync(request.PlatformIds, cancellationToken);
        
        if (genres.Count != request.GenreIds.Count)
        {
            return Result<Guid>.Failure("One or more genres not found.", ErrorType.NotFound);
        }
        
        if (platforms.Count != request.PlatformIds.Count)
        {
            return Result<Guid>.Failure("One or more platforms not found.", ErrorType.NotFound);
        }
        
        var game = new Game(
            request.Title,
            request.Description,
            request.DailyRentalPrice,
            request.PurchasePrice,
            request.ReleaseDate,
            request.AgeRating
        );
        game.AddGenres(genres);
        game.AddPlatforms(platforms);
        
        await gameRepository.AddAsync(game, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result<Guid>.Success(game.Id);
        
    }
}