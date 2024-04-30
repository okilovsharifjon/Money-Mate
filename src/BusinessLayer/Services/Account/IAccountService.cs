using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IAccountService
    {
        public Task<int> CreateAsync(AccountDto accountDto, CancellationToken token = default);
        public Task<AccountDto> GetByIdAsync(int id, CancellationToken token = default);
        public Task<AccountDtoUpdate> GetByIdAsyncForUpdate(int id, CancellationToken token = default);
        public Task<AccountDto> GetByNameAsync(string name, CancellationToken token = default);
        public Task UpdateAsync(int id, AccountDtoUpdate processDto, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
        
    }
}
