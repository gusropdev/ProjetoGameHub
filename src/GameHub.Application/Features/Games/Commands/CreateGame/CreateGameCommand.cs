using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.CreateGame;

public record CreateGameCommand (
    string Title,
    string Description,
    decimal DailyRentalPrice,
    decimal PurchasePrice,
    DateTime ReleaseDate,
    AgeRating AgeRating,
    List<int> GenreIds,
    List<int> PlatformIds
    ): IRequest<Result<Guid>>;