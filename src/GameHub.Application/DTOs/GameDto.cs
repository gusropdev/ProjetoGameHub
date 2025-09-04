using GameHub.Domain.Entities;
using GameHub.Domain.Enums;

namespace GameHub.Application.DTOs;

public class GameDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal DailyRentalPrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public DateTime ReleaseDate { get; set; }
    public AgeRating AgeRating { get; set; }
    public ICollection<GenreDto> Genres { get; set; } = null!;
    public ICollection<PlatformDto> Platforms { get; set; } = null!;
}