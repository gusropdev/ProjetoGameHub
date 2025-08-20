using GameHub.Domain.Enums;

namespace GameHub.Application.Features.Games.Commands.UpdateGame;

public record UpdateGameRequest(
    string Title,
    string Description,
    decimal DailyRentalPrice,
    DateTime ReleaseDate,
    AgeRating AgeRating,
    Genre Genre,
    Platform Platform);