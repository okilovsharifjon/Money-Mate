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
        IMapper mapper,
        IValidator<TransactionDto> validator,
        IValidator<TransactionDtoUpdate> validatorUp) : ITransactionService
    {
        private readonly TransactionRepositoryProxy _repositoryProxy = repositoryProxy;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<TransactionDtoUpdate> _validatorUp = validatorUp;
        private readonly IValidator<TransactionDto> _validator = validator;

        public async Task<int> CreateAsync(TransactionDto transactionDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(transactionDto, token);
            Transaction transaction = _mapper.Map<Transaction>(transactionDto);
            int id = await _repositoryProxy.CreateAsync(transaction, token);
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
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _repositoryProxy.DeleteAsync(id, token);
        }

    }
}
