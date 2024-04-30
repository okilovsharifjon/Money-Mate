using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Goal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public required string Name { get; set; }
        public required decimal AmountOfMoney { get; set; }
        public required DateTime Term {  get; set; }
    }
}
