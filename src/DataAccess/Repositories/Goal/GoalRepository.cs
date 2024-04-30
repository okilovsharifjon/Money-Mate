using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GoalRepository(FinancialDbContext dbContext) : IGoalRepository
    {
        private readonly FinancialDbContext _db = dbContext;

        public async Task<int> CreateAsync(Goal goal, CancellationToken token = default)
        {
            goal.Term.ToUniversalTime();
            await _db.Goals.AddAsync(goal, token);
            await _db.SaveChangesAsync(token);
            return goal.Id;
        }
        public async Task UpdateAsync(int id, Goal goal, CancellationToken token = default)
        {
            Goal goalChanges = await _db.Goals.SingleAsync(u => u.Id == id, token);
            goalChanges.Name = goal.Name;
            goalChanges.AmountOfMoney = goal.AmountOfMoney;
            goalChanges.Term = goal.Term;
            await _db.SaveChangesAsync(token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _db.Goals.Where(x => x.Id.Equals(id)).ExecuteDeleteAsync(token);
            await _db.SaveChangesAsync(token);
        }
        public async Task<Goal> GetByIdAsync(int id, CancellationToken token = default)
            => await _db.Goals.SingleAsync(x => x.Id == id, token);

        public async Task<Goal> GetByNameAsync(string name, CancellationToken token = default)
            => await _db.Goals.SingleAsync(x => x.Name == name, token);
    
    }
}
