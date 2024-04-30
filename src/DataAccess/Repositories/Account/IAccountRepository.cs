using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IAccountRepository
    {
        public Task<int> CreateAsync(Account account, CancellationToken token = default);
        public Task UpdateAsync(int id, Account account, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
        public Task<Account> GetByIdAsync(int id, CancellationToken token = default);
        public Task<Account> GetByNameAsync(string name, CancellationToken token = default);
    }
}
