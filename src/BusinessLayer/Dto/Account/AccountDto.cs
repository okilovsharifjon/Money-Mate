using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public readonly record struct AccountDto
        (
        int UserId,
        string Name,
        AccountType Type,
        decimal Balance
        );
}
