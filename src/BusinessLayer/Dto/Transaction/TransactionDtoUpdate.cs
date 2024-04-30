

using DataAccess;

namespace BusinessLayer
{
    public record TransactionDtoUpdate
    {
        public int AccountId { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
    }
}
