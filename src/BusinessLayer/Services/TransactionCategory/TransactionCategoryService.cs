
using AutoMapper;
using DataAccess;
using FluentValidation;

namespace BusinessLayer
{
    public class TransactionCategoryService(
        TransactionCategorRepositoryProxy repositoryProxy,
        IMapper mapper,
        IValidator<TransactionCategoryDto> validator) : ITransactionCategoryService
    {
        private readonly TransactionCategorRepositoryProxy _repositoryProxy = repositoryProxy;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<TransactionCategoryDto> _validator = validator;

        public async Task<int> CreateAsync(TransactionCategoryDto categoryDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(categoryDto, token);
            TransactionCategory category = _mapper.Map<TransactionCategory>(categoryDto);
            int id = await _repositoryProxy.CreateAsync(category, token);
            return id;

        }
        public async Task<TransactionCategoryDto> GetByIdAsync(int id, CancellationToken token = default)
        {
            TransactionCategoryDto categoryDto = _mapper.Map<TransactionCategoryDto>(await _repositoryProxy.GetByIdAsync(id, token));
            return categoryDto;
        }
        public async Task UpdateAsync(int id, TransactionCategoryDto categoryDto, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(categoryDto, token);
            TransactionCategory category = _mapper.Map<TransactionCategory>(categoryDto);
            await _repositoryProxy.UpdateAsync(id, category, token);
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _repositoryProxy.DeleteAsync(id, token);
        }

    }
}
