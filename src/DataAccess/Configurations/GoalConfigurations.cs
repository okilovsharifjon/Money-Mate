

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public sealed class GoalConfigurations : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder
                .ToTable("goal");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder
                .Property(p => p.UserId)
                .HasColumnName("user_id");

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Goals)
                .HasForeignKey(fk => fk.UserId)
                .IsRequired();

            builder
                .Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder
                .Property(p => p.AmountOfMoney)
                .HasColumnName("amount_of_money")
                .HasColumnType("MONEY")
                .IsRequired();

            builder
                .Property(p => p.Term)
                .HasColumnName("term")
                .HasColumnType("TIMESTAMP WITH TIME ZONE")
                .IsRequired();

        }
    }
}
