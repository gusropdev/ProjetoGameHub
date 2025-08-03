using GameHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameHub.Infrastructure.Persistence.Mappings;

public class GameMapping : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(g => g.Description)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Property(g => g.ReleaseDate)
            .IsRequired();

        builder.Property(g => g.DailyRentalPrice)
            .HasColumnType("MONEY");

        builder.Property(g => g.AgeRating)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(g => g.Platform)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(g => g.Genre)
            .IsRequired()
            .HasConversion<string>();
    }
}