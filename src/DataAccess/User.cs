

namespace DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<TransactionCategory> TransactionCategories { get; set; }
        public ICollection<UserSettings> UserSettings { get; set; }
    }
}
