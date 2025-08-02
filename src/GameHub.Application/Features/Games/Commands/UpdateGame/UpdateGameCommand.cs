using GameHub.Domain.Enums;
using MediatR;

namespace GameHub.Application.Features.Games.Commands.UpdateGame;

public record UpdateGameCommand(
    Guid GameId,
    string Title,
    string Description,
    string Genre,
    string Platform,
    decimal DailyRentalPrice,
    DateTime ReleaseDate,
    AgeRating AgeRating
) : IRequest<bool>;
