using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Transaction
    {
        public int Id {  get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public required DateTime Time {  get; set; }
        public required TransactionType Type { get; set; }
        public required decimal Amount { get; set; }
        public required string Category { get; set; }
        public string Description { get; set; }
    }
}
