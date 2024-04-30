

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("user");

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.FullName)
                .HasColumnName("full_name")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder
                .Property (p => p.Email)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder
                .Property(p => p.Password)
                .HasColumnName("password")
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder
                .Property(p => p.RegistrationDate)
                .HasColumnName("registration_date")
                .HasColumnType("TIMESTAMP")
                .IsRequired();

            builder
                .HasMany(p => p.Accounts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            builder
                .HasMany(p => p.Goals)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            builder
                .HasMany(p => p.Transactions)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            builder
                .HasMany(p => p.TransactionCategories)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            builder
                .HasMany(p => p.UserSettings)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .IsRequired();
        }
    }
}
