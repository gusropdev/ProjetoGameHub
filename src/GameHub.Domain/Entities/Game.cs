using GameHub.Domain.Enums;

namespace GameHub.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Genre { get; private set; }
    public string Platform { get; private set; }
    public decimal DailyRentalPrice { get; private set; }
    public int StockQuantity { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }
    
    public AgeRating AgeRating { get; private set; }
    
    private Game() { }
    
    public Game(string title, string description, string genre, string platform, decimal dailyRentalPrice, int stockQuantity, DateTime releaseDate, AgeRating ageRating)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        
        if (dailyRentalPrice < 0)
            throw new ArgumentException("Daily rental price cannot be negative.", nameof(dailyRentalPrice));
        
        if (stockQuantity < 0)
            throw new ArgumentException("Stock quantity cannot be negative.", nameof(stockQuantity));
        
        if (releaseDate < DateTime.Today)
            throw new ArgumentException("Release date cannot be in the future.", nameof(releaseDate));
        
        Id = Guid.NewGuid();
        Title = title;
        Description = string.IsNullOrWhiteSpace(description) ? string.Empty : description;
        Genre = string.IsNullOrWhiteSpace(genre) ? string.Empty : genre;
        Platform = string.IsNullOrWhiteSpace(platform) ? string.Empty : platform;
        DailyRentalPrice = dailyRentalPrice;
        StockQuantity = stockQuantity;
        ReleaseDate = releaseDate;
        AgeRating = ageRating;
        CreatedAt = DateTime.UtcNow;
        IsActive = true; // Default to active when created
    }
    
    public void Deactivate()
    {
        IsActive = false;
    }
    
    public void Activate()
    {
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

    public void UpdateGenre(string newGenre)
    {
        Genre = string.IsNullOrWhiteSpace(newGenre) ? string.Empty : newGenre;
    }

    public void UpdatePlatform(string newPlatform)
    {
        Platform = string.IsNullOrWhiteSpace(newPlatform) ? string.Empty : newPlatform;
    }
    
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice < 0)
            throw new ArgumentException("Price cannot be negative.", nameof(newPrice));
        
        DailyRentalPrice = newPrice;
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
    
}