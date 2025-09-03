using GameHub.Domain.Enums;

namespace GameHub.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }
    
    public Role Role { get; set; }
    public List<Rental> Rentals { get; private set; } = null!;

    private User(){ }

    public User(string fullName, string email, string? phoneNumber, Role role)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Email = email;
        PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber;
        CreatedAt = DateTime.UtcNow;
        IsActive = true; // Default to active when created
        Role = role;
        PasswordHash = string.Empty;
        Rentals = [];
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be empty or whitespace.", nameof(password));   
        }
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;
        
        return BCrypt.Net.BCrypt.Verify(password, this.PasswordHash);
    }

}