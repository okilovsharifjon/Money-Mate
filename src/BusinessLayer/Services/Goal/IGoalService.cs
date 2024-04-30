using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IGoalService
    {
        public Task<int> CreateAsync(GoalDto goalDto, CancellationToken token = default);
        public Task<GoalDto> GetByIdAsync(int id, CancellationToken token = default);
        public Task<GoalDtoUpdate> GetByIdAsyncForUpdate(int id, CancellationToken token = default);
        public Task<GoalDto> GetByNameAsync(string name, CancellationToken token = default);
        public Task UpdateAsync(int id, GoalDtoUpdate goalDto, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
    }
}
