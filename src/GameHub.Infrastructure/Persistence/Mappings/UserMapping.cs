using GameHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameHub.Infrastructure.Persistence.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.FullName)
            .HasColumnType("NVARCHAR")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(u => u.PhoneNumber)
            .HasColumnType("NVARCHAR")
            .IsRequired(false);
        
        builder.Property(u => u.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
    }
}