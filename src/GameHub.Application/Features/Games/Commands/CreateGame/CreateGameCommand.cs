using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.CreateGame;

public record CreateGameCommand (
    string Title,
    string Description,
    string Genre,
    string Platform,
    decimal DailyRentalPrice,
    int StockQuantity,
    DateTime ReleaseDate,
    AgeRating AgeRating
    ): IRequest<Guid>;