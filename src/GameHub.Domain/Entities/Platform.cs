using System.Text.Json.Serialization;

namespace GameHub.Domain.Entities;

public class Platform
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    
    public ICollection<Game> Games { get; private set; } = [];
    
    private Platform() { }

    public Platform(string name, int id)
    {
        Name = name;
        Id = id;
    }
}