using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public readonly record struct UserDto
        (
        string FullName,
        string Email,
        string Password
        );
}
