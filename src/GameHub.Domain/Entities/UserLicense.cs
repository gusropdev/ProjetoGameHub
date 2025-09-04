namespace GameHub.Domain.Entities;

public class Rental
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public decimal TotalRentalPrice { get; private set; }
    
    public Guid UserId { get; private set; }
    public Guid GameId { get; private set; }

    public User User { get; private set; } = null!;
    public Game Game { get; private set; } = null!;
    
    private Rental() { } 
    
    public Rental(Guid userId, Guid gameId, DateTime dueDate, decimal totalRentalPrice)
    {
        if (dueDate <= DateTime.UtcNow)
            throw new ArgumentException("Due date must be in the future.", nameof(dueDate));
        
        if (totalRentalPrice < 0)
            throw new ArgumentException("Rental price cannot be negative.", nameof(totalRentalPrice));
        
        Id = Guid.NewGuid();

        CreatedAt = DateTime.UtcNow;
        DueDate = dueDate;
        ReturnDate = null;
        TotalRentalPrice = totalRentalPrice;
        UserId = userId;
        GameId = gameId;
    }
}