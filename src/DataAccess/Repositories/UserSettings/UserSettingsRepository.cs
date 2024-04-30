using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserSettingsRepository(FinancialDbContext dbContext) : IUserSettingsRepository
    {
        private readonly FinancialDbContext _db = dbContext;

        public async Task<int> CreateAsync(UserSettings userSettings, CancellationToken token = default)
        {
            await _db.UserSettings.AddAsync(userSettings, token);
            await _db.SaveChangesAsync(token);
            return userSettings.Id;
        }
        public async Task UpdateAsync(int id, UserSettings userSettings, CancellationToken token = default)
        {
            UserSettings userSettingsChanges = await _db.UserSettings.SingleAsync(u => u.Id == id, token);
            userSettingsChanges.Currency = userSettings.Currency;
            await _db.SaveChangesAsync(token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _db.UserSettings.Where(x => x.Id.Equals(id)).ExecuteDeleteAsync(token);
            await _db.SaveChangesAsync(token);
        }
        public async Task<UserSettings> GetByIdAsync(int id, CancellationToken token = default)
            => await _db.UserSettings.SingleAsync(x => x.Id == id, token);


    }
}
