using GameHub.Domain.Enums;

namespace GameHub.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    public decimal DailyRentalPrice { get; private set; }
    public decimal PurchasePrice { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }

    public AgeRating AgeRating { get; private set; } = AgeRating.Everyone;
    public ICollection<Genre> Genres { get; private set; }
    public ICollection<Platform> Platforms { get; private set; }
    
    public ICollection<UserLicense> UserLicenses { get; private set; }
    
    private Game() { }
    
    public Game(
        string title,
        string description,
        decimal purchasePrice,
        decimal dailyRentalPrice,
        DateTime releaseDate,
        AgeRating ageRating)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        
        if (dailyRentalPrice < 0)
            throw new ArgumentException("Daily rental price cannot be negative.", nameof(dailyRentalPrice));
        
        if(purchasePrice < 0)
            throw new ArgumentException("Purchase price cannot be negative.", nameof(purchasePrice));
        
        if (releaseDate > DateTime.Today)
            throw new ArgumentException("Release date cannot be in the future.", nameof(releaseDate));
        
        Id = Guid.NewGuid();
        Title = title;
        Description = string.IsNullOrWhiteSpace(description) ? string.Empty : description;
        DailyRentalPrice = dailyRentalPrice;
        PurchasePrice = purchasePrice;
        ReleaseDate = releaseDate;
        CreatedAt = DateTime.UtcNow;
        IsActive = true; // Default to active when created
        AgeRating = ageRating;
        UserLicenses = [];
        Genres = [];
        Platforms = [];
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

    public void AddGenres(IEnumerable<Genre> genres)
    {
        foreach (var genre in genres)
            Genres.Add(genre);
    }

    public void AddPlatforms(IEnumerable<Platform> platforms)
    {
        foreach (var platform in platforms)
            Platforms.Add(platform);
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

    public void UpdatePurchasePrice(decimal newPurchasePrice)
    {
        if (newPurchasePrice < 0)
            throw new ArgumentException("Price cannot be negative.", nameof(newPurchasePrice));
        
        PurchasePrice = newPurchasePrice;
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
    
    public void UpdateGenres(ICollection<Genre> newGenres)
    {
        Genres.Clear();
        foreach (var genre in newGenres)
            Genres.Add(genre);
    }
    public void UpdatePlatforms(ICollection<Platform> newPlatforms)
    {
        Platforms.Clear();
        foreach (var platform in newPlatforms)
            Platforms.Add(platform);
    }
}