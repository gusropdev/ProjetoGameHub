using System.Diagnostics;
using GameHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameHub.Infrastructure.Persistence.Mappings;

public class UserLicenseMapping : IEntityTypeConfiguration<UserLicense>
{
    public void Configure(EntityTypeBuilder<UserLicense> builder)
    {
        builder.ToTable("UserLicenses");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.ActivatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        
        builder.Property(r => r.ExpiresAt)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.HasOne(r => r.User)
            .WithMany(u => u.UserLicenses)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Game)
            .WithMany(g => g.UserLicenses)
            .HasForeignKey(r => r.GameId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}