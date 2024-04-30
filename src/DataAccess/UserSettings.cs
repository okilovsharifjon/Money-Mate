﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserSettings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public required string Currency { get; set; }
    }
}
