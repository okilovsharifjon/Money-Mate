using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepositoryProxy(
        IDistributedCache cache,
        UserRepository originRepository) : IUserRepository
    {
        IDistributedCache _db = cache;
        UserRepository _originRepository = originRepository;

        public async Task<int> CreateAsync(User user, CancellationToken token = default)
        {
            int id = await _originRepository.CreateAsync(user, token);
            return id;
        }
        public async Task UpdateAsync(int id, User user, CancellationToken token = default)
        {
            await _originRepository.UpdateAsync(id, user, token);
            await _db.RefreshAsync(id.ToString(), token);
        }
        public async Task<User> GetByIdAsync(int id, CancellationToken token = default)
        {
            string? redisValue = await _db.GetStringAsync(id.ToString(), token);
            if(string.IsNullOrEmpty(redisValue))
            {
                User userFromDb = await _originRepository.GetByIdAsync(id, token);
                string userJson = JsonSerializer.Serialize(userFromDb);

                await _db.SetStringAsync(id.ToString(), userJson);
                return userFromDb;
            }
            string userJsonStr = redisValue.ToString();
            User user = JsonSerializer.Deserialize<User>(userJsonStr)
                  ?? throw new InvalidOperationException();
            return user;
        }
        public async Task<User> GetByNameAsync(string name, CancellationToken token = default)
            => await _originRepository.GetByNameAsync(name, token);
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _originRepository.DeleteAsync(id, token);
            await _db.RemoveAsync(id.ToString(), token);
        }

    }
}
