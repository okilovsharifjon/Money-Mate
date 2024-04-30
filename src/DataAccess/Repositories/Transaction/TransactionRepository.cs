using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TransactionRepository(FinancialDbContext dbContext) : ITransactionRepository
    {
        private readonly FinancialDbContext _db = dbContext;

        public async Task<int> CreateAsync(Transaction transaction, CancellationToken token = default)
        {
            transaction.Time = DateTime.Now;
            await _db.Transactions.AddAsync(transaction, token);
            await _db.SaveChangesAsync(token);
            return transaction.Id;
        }
        public async Task UpdateAsync(int id, Transaction transaction, CancellationToken token = default)
        {
            Transaction transactionChanges = await _db.Transactions.SingleAsync(u => u.Id == id, token);
            transactionChanges.Time = transaction.Time;
            transactionChanges.Type = transaction.Type;
            transactionChanges.Amount = transaction.Amount;
            transactionChanges.Category = transaction.Category;
            transactionChanges.Description = transaction.Description;
            await _db.SaveChangesAsync(token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _db.Transactions.Where(x => x.Id.Equals(id)).ExecuteDeleteAsync(token);
            await _db.SaveChangesAsync(token);
        }
        public async Task<Transaction> GetByIdAsync(int id, CancellationToken token = default)
            => await _db.Transactions.SingleAsync(x => x.Id == id, token);



    }
}
