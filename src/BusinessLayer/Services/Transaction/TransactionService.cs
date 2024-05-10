using AutoMapper;
using BusinessLayer.Services.Transaction;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TransactionService(
        TransactionRepositoryProxy repositoryProxy,
        AccountRepositoryProxy accountRepository,
        IMapper mapper,
        IValidator<TransactionDto> validator,
        IValidator<TransactionDtoUpdate> validatorUp) : ITransactionService
    {
        private readonly TransactionRepositoryProxy _repositoryProxy = repositoryProxy;
        private readonly AccountRepositoryProxy _accountRepository = accountRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<TransactionDtoUpdate> _validatorUp = validatorUp;
        private readonly IValidator<TransactionDto> _validator = validator;

        public async Task<int> CreateAsync(TransactionDto transactionDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(transactionDto, token);
            Transaction transaction = _mapper.Map<Transaction>(transactionDto);
            int id = await _repositoryProxy.CreateAsync(transaction, token);

            Account account = await _accountRepository.GetByIdAsync(transaction.AccountId);
            if (transaction.Type is TransactionType.Expense)
                account.Balance = account.Balance - transaction.Amount;
            else
                account.Balance = account.Balance + transaction.Amount;
            await _accountRepository.UpdateAsync(account.Id, account, token);

            return id;

        }
        public async Task<TransactionDto> GetByIdAsync(int id, CancellationToken token = default)
        {
            TransactionDto transactionDto = _mapper.Map<TransactionDto>(await _repositoryProxy.GetByIdAsync(id, token));
            return transactionDto;
        }
        public async Task UpdateAsync(int id, TransactionDtoUpdate transactionDto, CancellationToken token = default)
        {
            await _validatorUp.ValidateAndThrowAsync(transactionDto, token);
            Transaction transaction = _mapper.Map<Transaction>(transactionDto);
            await _repositoryProxy.UpdateAsync(id, transaction, token);

            Transaction lastTransaction = await _repositoryProxy.GetByIdAsync(id, token);   

            Account account = await _accountRepository.GetByIdAsync(transaction.AccountId);
            if (lastTransaction.Type is TransactionType.Expense)
            {
                account.Balance += lastTransaction.Amount;
                account.Balance -= transaction.Amount;
            }
            else
            {
                account.Balance -= lastTransaction.Amount;
                account.Balance += transaction.Amount;
            }
            await _accountRepository.UpdateAsync(account.Id, account, token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            Transaction lastTransaction = await _repositoryProxy.GetByIdAsync(id, token);

            Account account = await _accountRepository.GetByIdAsync(lastTransaction.AccountId);
            if (lastTransaction.Type is TransactionType.Expense)
            {
                account.Balance += lastTransaction.Amount;
            }
            else
            {
                account.Balance -= lastTransaction.Amount;
            }
            await _accountRepository.UpdateAsync(account.Id, account, token);

            await _repositoryProxy.DeleteAsync(id, token);
        }

    }
}
