

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .ToTable("account");

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .HasKey(k => k.Id);

            builder
                .Property(p => p.UserId)
                .HasColumnName("user_id");

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Accounts)
                .HasForeignKey(fk => fk.UserId)
                .IsRequired();

            builder
                .HasMany(p => p.Transactions)
                .WithOne(p => p.Account)
                .HasForeignKey(fk => fk.AccountId)
                .IsRequired();

            builder
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder
                .Property(p => p.Balance)
                .HasColumnName("balance")
                .HasColumnType("MONEY")
                .IsRequired();

            builder
                .Property(p => p.Type)
                .HasColumnName("type")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
