using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TransactionRepositoryProxy(
        IDistributedCache distributedCache,
        TransactionRepository transactionRepository) : ITransactionRepository
    {
        IDistributedCache _db = distributedCache;

        TransactionRepository _originRepository = transactionRepository;
        

        public async Task<int> CreateAsync(Transaction transaction, CancellationToken token = default)
        {
            int id = await _originRepository.CreateAsync(transaction, token);
            return id;
        }
        public async Task UpdateAsync(int id, Transaction transaction, CancellationToken token = default)
        {
            await _originRepository.UpdateAsync(id, transaction, token);
            await _db.RefreshAsync(id.ToString(), token);
        }
        public async Task<Transaction> GetByIdAsync(int id, CancellationToken token = default)
        {
            string? redisValue = await _db.GetStringAsync(id.ToString(), token);
            if (string.IsNullOrEmpty(redisValue))
            {
                Transaction transactionFromDb = await _originRepository.GetByIdAsync(id, token);
                string goalJson = JsonSerializer.Serialize(transactionFromDb);

                await _db.SetStringAsync(id.ToString(), goalJson);
                return transactionFromDb;
            }
            string transactionJsonStr = redisValue.ToString();
            Transaction transactionOut = JsonSerializer.Deserialize<Transaction>(transactionJsonStr)
                  ?? throw new InvalidOperationException();
            return transactionOut;
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _originRepository.DeleteAsync(id, token);
            await _db.RemoveAsync(id.ToString(), token);
        }
    
    }
}
