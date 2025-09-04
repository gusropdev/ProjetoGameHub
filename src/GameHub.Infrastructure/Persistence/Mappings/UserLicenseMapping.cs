using GameHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameHub.Infrastructure.Persistence.Mappings;

public class RentalMapping : IEntityTypeConfiguration<UserLicense>
{
    public void Configure(EntityTypeBuilder<UserLicense> builder)
    {
        builder.ToTable("Rentals");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        
        builder.Property(r => r.DueDate)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(r => r.ReturnDate)
            .HasColumnType("DATETIME")
            .IsRequired(false);
        
        builder.Property(r => r.TotalRentalPrice)
            .IsRequired()
            .HasPrecision(19, 4)
            .HasColumnType("SMALLMONEY");

        builder.HasOne(r => r.User)
            .WithMany(u => u.Rentals)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Game)
            .WithMany(g => g.UserLicenses)
            .HasForeignKey(r => r.GameId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}