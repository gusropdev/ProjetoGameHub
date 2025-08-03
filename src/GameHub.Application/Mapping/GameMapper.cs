using GameHub.Application.DTOs;
using GameHub.Domain.Entities;

namespace GameHub.Application.Mapping;

public static class GameMapper
{
    public static GameDto MapToDto(this Game game)
    {
        return new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            Description = game.Description,
            DailyRentalPrice = game.DailyRentalPrice,
            StockQuantity = game.StockQuantity,
            ReleaseDate = game.ReleaseDate,
            AgeRating = game.AgeRating,
            Genre = game.Genre,
            Platform = game.Platform,
        };
    }
}