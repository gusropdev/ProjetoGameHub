using GameHub.Domain.Enums;

namespace GameHub.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }
    public string PasswordHash { get; private set; } = null!; // Eventualmente mudar para byte[] para armazenar o hash de senha
    // public byte[] PasswordSalt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }
    
    public Role Role { get; set; }
    public List<Rental> Rentals { get; private set; } = null!;

    private User(){ }

    public User(string fullName, string email, string passwordHash, string phoneNumber, Role role)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Name cannot be empty.", nameof(fullName));
        
        if(fullName.Length < 3)
            throw new ArgumentException("Name must be at least 3 characters long.", nameof(fullName));
        
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.", nameof(email));
        
        Id = Guid.NewGuid();
        FullName = fullName;
        Email = email;
        PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
        IsActive = true; // Default to active when created
        Role = role;
        Rentals = [];
    }

}