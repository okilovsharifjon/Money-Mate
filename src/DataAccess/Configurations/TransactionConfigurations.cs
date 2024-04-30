
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public sealed class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                .ToTable("transaction");

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.UserId)
                .HasColumnName("user_id");

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Transactions)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            builder
                .Property(p => p.AccountId)
                .HasColumnName("account_id");

            builder
                .HasOne(p => p.Account)
                .WithMany(p => p.Transactions)
                .HasForeignKey(p => p.AccountId)
                .IsRequired();

            builder
                .Property(p => p.Time)
                .HasColumnName("time")
                .HasColumnType("TIMESTAMP")
                .IsRequired();

            builder
                .Property(p => p.Type)
                .HasColumnName("type")
                .HasConversion<string>()
                .IsRequired();

            builder
                .Property(p => p.Amount)
                .HasColumnName("amount")
                .HasColumnType("MONEY")
                .IsRequired();

            builder
                .Property(p => p.Category)
                .HasColumnName("category")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(500)")
                .IsRequired(false);
        }
    }
}
