using AutoMapper;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccountService(
        AccountRepositoryProxy repositoryProxy,
        IMapper mapper,
        IValidator<AccountDto> validator,
        IValidator<AccountDtoUpdate> validatorUp) : IAccountService
    {
        private readonly AccountRepositoryProxy _accountRepository = repositoryProxy;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<AccountDto> _validator = validator;
        private readonly IValidator<AccountDtoUpdate> _validatorUp = validatorUp;

        public async Task<int> CreateAsync(AccountDto accountDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(accountDto, token);
            Account account = _mapper.Map<Account>(accountDto);
            int id = await _accountRepository.CreateAsync(account, token);
            return id;

        }
        public async Task<AccountDto> GetByIdAsync(int id, CancellationToken token = default)
            => _mapper.Map<AccountDto>(await _accountRepository.GetByIdAsync(id, token));
        public async Task<AccountDtoUpdate> GetByIdAsyncForUpdate(int id, CancellationToken token = default)
            => _mapper.Map<AccountDtoUpdate>(await _accountRepository.GetByIdAsync(id, token));

        public async Task<AccountDto> GetByNameAsync(string name, CancellationToken token = default)
        {
            AccountDto accountDto = _mapper.Map<AccountDto>(await _accountRepository.GetByNameAsync(name, token));
            return accountDto;
        }
        public async Task UpdateAsync(int id, AccountDtoUpdate accountDto, CancellationToken token = default)
        {
            await _validatorUp.ValidateAndThrowAsync(accountDto, token);
            Account account = _mapper.Map<Account>(accountDto);
            await _accountRepository.UpdateAsync(id, account, token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _accountRepository.DeleteAsync(id, token);
        }
        
    }
}
