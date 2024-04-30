

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public sealed class UserSettingsConfigurations : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder
                .ToTable("user_settings");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(x => x.UserId)
                .HasColumnName("user_id");

            builder
                .HasOne(p => p.User)
                .WithMany(x => x.UserSettings)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder
                .Property(p => p.Currency)
                .HasColumnName("currency")
                .HasColumnType("VARCHAR(3)")
                .IsRequired();
        }
    }
}
