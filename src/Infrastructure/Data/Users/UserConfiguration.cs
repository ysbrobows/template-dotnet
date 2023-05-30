using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.ValueObjects;

namespace Infrastructure.Data.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.HasIndex(x => x.Username);
        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion(u => u.ToString(), u => new Email(u));

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
