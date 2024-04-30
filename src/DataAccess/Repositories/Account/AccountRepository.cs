using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountRepository(FinancialDbContext dbContext) : IAccountRepository
    {
        private readonly FinancialDbContext _db = dbContext;

        public async Task<int> CreateAsync(Account account, CancellationToken token = default)
        {
            await _db.Accounts.AddAsync(account, token);
            await _db.SaveChangesAsync(token);
            return account.Id;
        }
        public async Task UpdateAsync(int id, Account account, CancellationToken token = default)
        {
            Account accountChanges = await _db.Accounts.SingleAsync(u => u.Id == id, token);
            accountChanges.Name = account.Name;
            accountChanges.Balance = account.Balance;
            await _db.SaveChangesAsync(token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _db.Accounts.Where(x => x.Id.Equals(id)).ExecuteDeleteAsync(token);
            await _db.SaveChangesAsync(token);
        }
        public async Task<Account> GetByIdAsync(int id, CancellationToken token = default)
            => await _db.Accounts.SingleAsync(x => x.Id == id, token);

        public async Task<Account> GetByNameAsync(string name, CancellationToken token = default)
            => await _db.Accounts.SingleAsync(x => x.Name == name, token);
    }
}
