using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ITransactionRepository
    {
        public Task<int> CreateAsync(Transaction transaction, CancellationToken token = default);
        public Task UpdateAsync(int id, Transaction transaction, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
        public Task<Transaction> GetByIdAsync(int id, CancellationToken token = default);
        //public Task<Transaction> GetByNameAsync(string name, CancellationToken token = default);
    }
}
