using GameHub.Domain.Enums;

namespace GameHub.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    public decimal DailyRentalPrice { get; private set; }
    public int StockQuantity { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }

    public AgeRating AgeRating { get; private set; } = AgeRating.Everyone;
    public Genre Genre { get; private set; } = Genre.Other;
    public Platform Platform { get; private set; } = Platform.Other;
    
    public List<Rental> Rentals { get; private set; } = null!;
    
    private Game() { }
    
    public Game(
        string title,
        string description,
        decimal dailyRentalPrice,
        int stockQuantity,
        DateTime releaseDate,
        AgeRating ageRating,
        Genre genre,
        Platform platform)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        
        if (dailyRentalPrice < 0)
            throw new ArgumentException("Daily rental price cannot be negative.", nameof(dailyRentalPrice));
        
        if (stockQuantity < 0)
            throw new ArgumentException("Stock quantity cannot be negative.", nameof(stockQuantity));
        
        if (releaseDate >  DateTime.Today)
            throw new ArgumentException("Release date cannot be in the future.", nameof(releaseDate));
        
        Id = Guid.NewGuid();
        Title = title;
        Description = string.IsNullOrWhiteSpace(description) ? string.Empty : description;
        DailyRentalPrice = dailyRentalPrice;
        StockQuantity = stockQuantity;
        ReleaseDate = releaseDate;
        CreatedAt = DateTime.UtcNow;
        IsActive = true; // Default to active when created
        AgeRating = ageRating;
        Genre = genre;
        Platform = platform;
        Rentals = [];
    }
    
    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("Game is already inactive.");
        IsActive = false;
    }
    
    public void Activate()
    {
        if (IsActive)
            throw new InvalidOperationException("Game is already active.");
        IsActive = true;
    }
    
    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        
        StockQuantity += quantity;
    }
    
    public void RemoveStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        
        if (quantity > StockQuantity)
            throw new InvalidOperationException("Insufficient stock to remove the specified quantity.");
        
        StockQuantity -= quantity;
    }
    
    public void UpdateTitle(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Title cannot be empty.", nameof(newTitle));
        
        Title = newTitle;
    }

    public void UpdateDescription(string newDescription)
    {
        Description = string.IsNullOrWhiteSpace(newDescription) ? string.Empty : newDescription;
    }
    
    public void UpdateDailyRentalPrice(decimal newDailyRentalPrice)
    {
        if (newDailyRentalPrice < 0)
            throw new ArgumentException("Price cannot be negative.", nameof(newDailyRentalPrice));
        
        DailyRentalPrice = newDailyRentalPrice;
    }
    
    public void UpdateReleaseDate(DateTime newReleaseDate)
    {
        if (newReleaseDate > DateTime.UtcNow)
            throw new ArgumentException("Release date cannot be in the future.", nameof(newReleaseDate));
        
        ReleaseDate = newReleaseDate;
    }
    
    public void UpdateAgeRating(AgeRating newAgeRating)
    {
        AgeRating = newAgeRating;
    }

    public void UpdateGenre(Genre newGenre)
    {
        Genre = newGenre;
    }
    
    public void UpdatePlatform(Platform newPlatform)
    {
        Platform = newPlatform;
    }
}