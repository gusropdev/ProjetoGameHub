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
            .HasColumnType("NVARCHAR")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(g => g.Description)
            .HasColumnType("NVARCHAR")
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Property(g => g.ReleaseDate)
            .HasColumnType("DATETIME")
            .IsRequired();
        
        builder.Property(g => g.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(g => g.DailyRentalPrice)
            .IsRequired()
            .HasPrecision(19, 4)
            .HasColumnType("SMALLMONEY");

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