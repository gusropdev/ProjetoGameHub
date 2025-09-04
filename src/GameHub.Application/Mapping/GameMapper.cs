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
            PurchasePrice = game.PurchasePrice,
            ReleaseDate = game.ReleaseDate,
            AgeRating = game.AgeRating,
            
            Genres = game.Genres.Select(genre => genre.MapToDto()).ToList(),
            Platforms = game.Platforms.Select(platform => platform.MapToDto()).ToList()
        };
    }
}