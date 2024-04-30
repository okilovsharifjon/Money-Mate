

using AutoMapper;
using BusinessLayer.Services.Transaction;
using DataAccess;
using FluentValidation;

namespace BusinessLayer
{
    public class UserSettingsService(
        UserSettingsRepository repositoryProxy,
        IMapper mapper,
        IValidator<UserSettingsDto> validator) : IUserSettingsService
    {
        private readonly UserSettingsRepository _repositoryProxy = repositoryProxy;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<UserSettingsDto> _validator = validator;

        public async Task<int> CreateAsync(UserSettingsDto userSettingsDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(userSettingsDto, token);
            UserSettings userSettings = _mapper.Map<UserSettings>(userSettingsDto);
            int id = await _repositoryProxy.CreateAsync(userSettings, token);
            return id;

        }
        public async Task<UserSettingsDto> GetByIdAsync(int id, CancellationToken token = default)
        {
            UserSettingsDto userSettingsDto = _mapper.Map<UserSettingsDto>(await _repositoryProxy.GetByIdAsync(id, token));
            return userSettingsDto;
        }
        public async Task UpdateAsync(int id, UserSettingsDto userSettingsDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(userSettingsDto, token);
            UserSettings userSettings = _mapper.Map<UserSettings>(userSettingsDto);
            await _repositoryProxy.UpdateAsync(id, userSettings, token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _repositoryProxy.DeleteAsync(id, token);
        }

    }
}
