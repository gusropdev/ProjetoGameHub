using FluentValidation;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using GameHub.Domain.Repositories;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.DeleteGame;

public class DeleteGameCommandHandler (IGameRepository gameRepository, IValidator<DeleteGameCommand> validator, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteGameCommand, Result>
{
    public async Task<Result> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            
            return Result.Failure(errorMessages);
        }
        
        var game = await gameRepository.GetByIdAsync(request.Id, cancellationToken);
        if (game == null)
        {
            return Result.Failure("Game not found.", ErrorType.NotFound);
        }
        
        gameRepository.Delete(game, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}