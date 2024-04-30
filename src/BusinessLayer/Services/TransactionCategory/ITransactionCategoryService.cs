using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ITransactionCategoryService
    {
        public Task<int> CreateAsync(TransactionCategoryDto categoryDto, CancellationToken token = default);
        public Task<TransactionCategoryDto> GetByIdAsync(int id, CancellationToken token = default);
        public Task UpdateAsync(int id, TransactionCategoryDto categoryDto, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
    }
}
