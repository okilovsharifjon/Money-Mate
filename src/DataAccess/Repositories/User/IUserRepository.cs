using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal interface IUserRepository
    {
        public Task<int> CreateAsync(User user, CancellationToken token = default);
        public Task UpdateAsync(int id, User user, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
        public Task<User> GetByIdAsync(int id, CancellationToken token = default);
        public Task<User> GetByNameAsync(string name, CancellationToken token = default);
    }
}
