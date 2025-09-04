using GameHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameHub.Infrastructure.Persistence.Mappings;

public class PlatformMapping : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("NVARCHAR")
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new Platform("PC (Windows)", 1),
            new Platform("MacOS", 2),
            new Platform("Linux", 3),
            new Platform("PlayStation 4", 4),
            new Platform("PlayStation 5", 5),
            new Platform("Xbox One", 6),
            new Platform("Xbox Series X/S", 7),
            new Platform("Nintendo Switch", 8),
            new Platform("Android", 9),
            new Platform("iOS", 10),
            new Platform("VR", 11),
            new Platform("Cloud Gaming", 12)

        );
    }
}