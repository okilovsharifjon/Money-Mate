using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUserSettingsRepository
    {
        public Task<int> CreateAsync(UserSettings userSettings, CancellationToken token = default);
        public Task UpdateAsync(int id, UserSettings userSettings, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
        public Task<UserSettings> GetByIdAsync(int id, CancellationToken token = default);
    }
}
