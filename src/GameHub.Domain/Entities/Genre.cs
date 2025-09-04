using System.Text.Json.Serialization;

namespace GameHub.Domain.Entities;

public class Genre
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    
    public ICollection<Game> Games { get; private set; } = [];
    
    private Genre() { }
    
    public Genre(string name, int id)
    {
        Id = id;
        Name = name;
    }
}