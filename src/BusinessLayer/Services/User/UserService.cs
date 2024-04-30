

using AutoMapper;
using DataAccess;
using FluentValidation;

namespace BusinessLayer
{
    public class UserService(
        UserRepositoryProxy repositoryProxy,
        IMapper mapper,
        IValidator<UserDto> validator,
        IValidator<UserDtoUpdate> validatorUp) : IUserService
    {
        private readonly UserRepositoryProxy _userRepository = repositoryProxy;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<UserDto> _validator = validator;
        private readonly IValidator<UserDtoUpdate> _validatorUpdate = validatorUp;

        public async Task<int> CreateAsync(UserDto userDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(userDto, token);
            User user = _mapper.Map<User>(userDto);
            int id = await _userRepository.CreateAsync(user, token);
            return id;

        }
        public async Task<UserDto> GetByIdAsync(int id, CancellationToken token = default)
            => _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(id, token));
        public async Task<UserDtoUpdate> GetByIdAsyncForUpdate(int id, CancellationToken token = default)
        {
            UserDtoUpdate userDto = _mapper.Map<UserDtoUpdate>(await _userRepository.GetByIdAsync(id, token));
            return userDto;
        }
        public async Task<UserDto> GetByNameAsync(string name, CancellationToken token = default)
        {
            UserDto userDto = _mapper.Map<UserDto>(await _userRepository.GetByNameAsync(name, token));
            return userDto;
        }
        public async Task UpdateAsync(int id, UserDtoUpdate userDto, CancellationToken token = default)
        {
            await _validatorUpdate.ValidateAndThrowAsync(userDto, token);
            User user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(id, user, token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _userRepository.DeleteAsync(id, token);
        }

    }
}
