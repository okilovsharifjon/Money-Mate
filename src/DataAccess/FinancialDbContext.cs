using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess
{
    public sealed class FinancialDbContext(DbContextOptions options) : DbContext(options)
    {
       // string redisHost = "localhost";
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<Goal> Goals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=money_mate_db;Username=postgres;Password=admin;Pooling=true;");
        }*/

    }
}
