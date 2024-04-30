using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ITransactionCategoryRepository
    {
        public Task<int> CreateAsync(TransactionCategory category, CancellationToken token = default);
        public Task UpdateAsync(int id, TransactionCategory category, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
        public Task<TransactionCategory> GetByIdAsync(int id, CancellationToken token = default);
    }
}
