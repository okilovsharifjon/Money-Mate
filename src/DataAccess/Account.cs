using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public required string Name { get; set; }
        public AccountType Type { get; set; }
        public required decimal Balance { get; set; } 
        public ICollection<Transaction> Transactions { get; set; }

    }
}
