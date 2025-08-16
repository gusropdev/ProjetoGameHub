using GameHub.Domain.Enums;

namespace GameHub.Application.DTOs;

public class GameDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal DailyRentalPrice { get; set; }
    public int StockQuantity { get; set; }
    public DateTime ReleaseDate { get; set; }
    
    public AgeRating AgeRating { get; set; }
    public Genre Genre { get; set; }
    public Platform Platform { get; set; }
}