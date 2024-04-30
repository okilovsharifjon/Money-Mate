using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository(FinancialDbContext dbContext) : IUserRepository
    {
        private readonly FinancialDbContext _db = dbContext;

        public async Task<int> CreateAsync(User user, CancellationToken token = default)
        {
            user.RegistrationDate = DateTime.Now; //user.RegistrationDate.ToLocalTime();
            await _db.Users.AddAsync(user, token);
            await _db.SaveChangesAsync(token);
            return user.Id;
        }
        public async Task UpdateAsync(int id, User user, CancellationToken token = default)
        {
            User userChanges = await _db.Users.SingleAsync(u => u.Id.Equals(id), token);
            userChanges.FullName = user.FullName;
            userChanges.Email = user.Email;
            userChanges.Password = user.Password;
            await _db.SaveChangesAsync(token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _db.Users.Where(x => x.Id.Equals(id)).ExecuteDeleteAsync(token);
            await _db.SaveChangesAsync(token);
        }
        public async Task<User> GetByIdAsync(int id, CancellationToken token = default)
            => await _db.Users.SingleAsync(x => x.Id.Equals(id), token);

        public async Task<User> GetByNameAsync(string name, CancellationToken token = default)
            => await _db.Users.SingleAsync(x => x.FullName == name, token);
    }
}
