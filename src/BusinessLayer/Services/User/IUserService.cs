using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IUserService
    {
        public Task<int> CreateAsync(UserDto userDto, CancellationToken token = default);
        public Task<UserDto> GetByIdAsync(int id, CancellationToken token = default);
        public Task<UserDtoUpdate> GetByIdAsyncForUpdate(int id, CancellationToken token = default);
        public Task<UserDto> GetByNameAsync(string name, CancellationToken token = default);
        public Task UpdateAsync(int id, UserDtoUpdate userDto, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
    }
}
