using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountRepositoryProxy(
        IDistributedCache cache,
        AccountRepository originRepository) : IAccountRepository
    {
        IDistributedCache _db = cache;
        AccountRepository _originRepository = originRepository;
        public async Task<int> CreateAsync(Account account, CancellationToken token = default)
        {
            int id = await _originRepository.CreateAsync(account, token);
            return id;
        }
        public async Task UpdateAsync(int id, Account account, CancellationToken token = default)
        {
            await _originRepository.UpdateAsync(id, account, token);
            await _db.RefreshAsync(id.ToString(), token);
        }
        public async Task<Account> GetByIdAsync(int id, CancellationToken token = default)
        {
            string? redisValue = await _db.GetStringAsync(id.ToString(), token);
            if (string.IsNullOrEmpty(redisValue))
            {
                Account accountFromDb = await _originRepository.GetByIdAsync(id, token);
                string accountJson = JsonSerializer.Serialize(accountFromDb);

                await _db.SetStringAsync(id.ToString(), accountJson);
                return accountFromDb;
            }
            string accountJsonStr = redisValue.ToString();
            Account accountOut = JsonSerializer.Deserialize<Account>(accountJsonStr)
                  ?? throw new InvalidOperationException();
            return accountOut;
        }
        public async Task<Account> GetByNameAsync(string name, CancellationToken token = default)
            => await _originRepository.GetByNameAsync(name, token);
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _originRepository.DeleteAsync(id, token);
            await _db.RemoveAsync(id.ToString(), token);
        }
    }
}
