using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TransactionCategory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public required string Name { get; set; }
        /*
        Food,
        Transportation,
        Entertaiment,
        Utilities,
        Health,
        Education,
        Other*/
    }
}
