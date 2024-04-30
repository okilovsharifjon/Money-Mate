

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public sealed class TransactionCategoryConfigurations : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder
                .ToTable("transaction_category");

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
                .WithMany(p => p.TransactionCategories)
                .HasForeignKey(fk => fk.UserId)
                .IsRequired();

            builder
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

        }
    }
}
