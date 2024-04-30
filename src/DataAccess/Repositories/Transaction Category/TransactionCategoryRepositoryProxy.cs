using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TransactionCategorRepositoryProxy(
        IDistributedCache distributedCache,
        TransactionCategoryRepository categoryRepository) : ITransactionCategoryRepository
    {
        IDistributedCache _db = distributedCache;

        TransactionCategoryRepository _originRepository = categoryRepository;

        public async Task<int> CreateAsync(TransactionCategory category, CancellationToken token = default)
        {
            int id = await _originRepository.CreateAsync(category, token);
            return id;
        }
        public async Task UpdateAsync(int id, TransactionCategory category, CancellationToken token = default)
        {
            await _originRepository.UpdateAsync(id, category, token);
            await _db.RefreshAsync(id.ToString(), token);
        }
        public async Task<TransactionCategory> GetByIdAsync(int id, CancellationToken token = default)
        {
            string? redisValue = await _db.GetStringAsync(id.ToString(), token);
            if (string.IsNullOrEmpty(redisValue))
            {
                TransactionCategory categoryFromDb = await _originRepository.GetByIdAsync(id, token);
                string goalJson = JsonSerializer.Serialize(categoryFromDb);

                await _db.SetStringAsync(id.ToString(), goalJson);
                return categoryFromDb;
            }
            string categoryJsonStr = redisValue.ToString();
            TransactionCategory categoryOut = JsonSerializer.Deserialize<TransactionCategory>(categoryJsonStr)
                  ?? throw new InvalidOperationException();
            return categoryOut;
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _originRepository.DeleteAsync(id, token);
            await _db.RemoveAsync(id.ToString(), token);
        }

    }
}
