using GameHub.Application.Common;
using GameHub.Application.Common.Responses;
using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.CreateGame;

public record CreateGameCommand (
    string Title,
    string Description,
    decimal DailyRentalPrice,
    int StockQuantity,
    DateTime ReleaseDate,
    AgeRating AgeRating,
    Genre Genre,
    Platform Platform
    ): IRequest<Result<Guid>>;