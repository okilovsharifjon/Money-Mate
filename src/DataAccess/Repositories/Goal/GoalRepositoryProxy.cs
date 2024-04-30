using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GoalRepositoryProxy(
        IDistributedCache distributedCache,
        GoalRepository goalRepository) : IGoalRepository
    {
        IDistributedCache _db = distributedCache;

        GoalRepository _originRepository = goalRepository;

        public async Task<int> CreateAsync(Goal goal, CancellationToken token = default)
        {
            int id = await _originRepository.CreateAsync(goal, token);
            return id;
        }
        public async Task UpdateAsync(int id, Goal goal, CancellationToken token = default)
        {
            await _originRepository.UpdateAsync(id, goal, token);
            await _db.RefreshAsync(id.ToString(), token);
        }
        public async Task<Goal> GetByIdAsync(int id, CancellationToken token = default)
        {
            string? redisValue = await _db.GetStringAsync(id.ToString(), token);
            if (string.IsNullOrEmpty(redisValue))
            {
                Goal goalFromDb = await _originRepository.GetByIdAsync(id, token);
                string goalJson = JsonSerializer.Serialize(goalFromDb);

                await _db.SetStringAsync(id.ToString(), goalJson);
                return goalFromDb;
            }
            string goalJsonStr = redisValue.ToString();
            Goal goalOut = JsonSerializer.Deserialize<Goal>(goalJsonStr)
                  ?? throw new InvalidOperationException();
            return goalOut;
        }
        public async Task<Goal> GetByNameAsync(string name, CancellationToken token = default)
            => await _originRepository.GetByNameAsync(name, token);
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _originRepository.DeleteAsync(id, token);
            await _db.RemoveAsync(id.ToString(), token);
        }
    }
}
