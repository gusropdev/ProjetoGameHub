using GameHub.Domain.Enums;

namespace GameHub.Application.Features.Games.Commands.UpdateGame;

public record UpdateGameRequest(
    string Title,
    string Description,
    decimal DailyRentalPrice,
    decimal PurchasePrice,
    DateTime ReleaseDate,
    AgeRating AgeRating,
    List<int> GenreIds,
    List<int> PlatformIds);