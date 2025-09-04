using GameHub.Domain.Enums;

namespace GameHub.Domain.Entities;

public class UserLicense
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid GameId { get; private set; }
    
    public DateTime ActivatedAt { get; private set; }
    public DateTime? ExpiresAt { get; private set; }
    public LicenseType LicenseType { get; private set; } 

    public User User { get; private set; } = null!;
    public Game Game { get; private set; } = null!;
    
    private UserLicense() { } 
    
    private UserLicense(Guid userId, Guid gameId, int accessDurationInDays)
    {
        if (accessDurationInDays <= 0)
            throw new ArgumentException("Access duration must be 1 day or more.", nameof(accessDurationInDays));
        
        Id = Guid.NewGuid();
        ActivatedAt = DateTime.UtcNow;
        ExpiresAt = DateTime.UtcNow.AddDays(accessDurationInDays);
        LicenseType = LicenseType.Rental;
        UserId = userId;
        GameId = gameId;
    }
    
    private UserLicense(Guid userId, Guid gameId)
    {
        Id = Guid.NewGuid();
        ActivatedAt = DateTime.UtcNow;
        ExpiresAt = null;
        LicenseType = LicenseType.Purchase;
        UserId = userId;
        GameId = gameId;
    }
    
    public static UserLicense CreateRental(Guid userId, Guid gameId, int accessDurationInDays)
        => new UserLicense(userId, gameId, accessDurationInDays);

    public static UserLicense CreatePurchase(Guid userId, Guid gameId)
        => new UserLicense(userId, gameId);

}