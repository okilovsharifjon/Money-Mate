using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal interface IGoalRepository
    {
        public Task<int> CreateAsync(Goal goal, CancellationToken token = default);
        public Task UpdateAsync(int id, Goal goal, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
        public Task<Goal> GetByIdAsync(int id, CancellationToken token = default);
        public Task<Goal> GetByNameAsync(string name, CancellationToken token = default);
    }
}
