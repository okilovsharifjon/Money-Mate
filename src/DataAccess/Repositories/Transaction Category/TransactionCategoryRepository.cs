using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TransactionCategoryRepository(FinancialDbContext dbContext) : ITransactionCategoryRepository
    {
        private readonly FinancialDbContext _db = dbContext;

        public async Task<int> CreateAsync(TransactionCategory category, CancellationToken token = default)
        {
            await _db.TransactionCategories.AddAsync(category, token);
            await _db.SaveChangesAsync(token);
            return category.Id;
        }
        public async Task UpdateAsync(int id, TransactionCategory category, CancellationToken token = default)
        {
            TransactionCategory categoryChanges = await _db.TransactionCategories.SingleAsync(u => u.Id == id, token);
            categoryChanges.Name = category.Name;
            await _db.SaveChangesAsync(token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _db.TransactionCategories.Where(x => x.Id.Equals(id)).ExecuteDeleteAsync(token);
            await _db.SaveChangesAsync(token);
        }
        public async Task<TransactionCategory> GetByIdAsync(int id, CancellationToken token = default)
            => await _db.TransactionCategories.SingleAsync(x => x.Id == id, token);


    }
}
