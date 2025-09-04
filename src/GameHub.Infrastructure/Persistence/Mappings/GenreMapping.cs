using GameHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameHub.Infrastructure.Persistence.Mappings;

public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("NVARCHAR")
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasData(
            new Genre("Action", 1),
            new Genre("Adventure", 2),
            new Genre("RPG", 3),
            new Genre("Strategy", 4),
            new Genre("Sports", 5),
            new Genre("MMORPG",6),
            new Genre("Simulation", 7),
            new Genre("Puzzle", 8),
            new Genre("Idle", 9),
            new Genre("Horror", 10),
            new Genre("Shooter", 11),
            new Genre("Fighting", 12),
            new Genre("Platformer", 13),
            new Genre("Racing", 14),
            new Genre("Music", 16),
            new Genre("Educational", 17),
            new Genre("Roguelike", 18),
            new Genre("Visual Novel", 19),
            new Genre("Party", 20),
            new Genre("Stealth", 21),
            new Genre("Survival", 22),
            new Genre("Battle Royale", 23),
            new Genre("Metroidvania", 24),
            new Genre("MOBA", 25),
            new Genre("Card Game", 26),
            new Genre("Board Game", 27),
            new Genre("Arcade", 28),
            new Genre("Rhythm", 29),
            new Genre("Tycoon", 30),
            new Genre("Other", 31)
        );
    }
}