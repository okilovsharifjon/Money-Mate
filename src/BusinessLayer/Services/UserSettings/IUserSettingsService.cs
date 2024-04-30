

namespace BusinessLayer
{
    public interface IUserSettingsService
    {
        public Task<int> CreateAsync(UserSettingsDto userSettingsDto, CancellationToken token = default);
        public Task<UserSettingsDto> GetByIdAsync(int id, CancellationToken token = default);
        public Task UpdateAsync(int id, UserSettingsDto userSettingsDto, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
    }
}
