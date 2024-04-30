using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Transaction
{
    public interface ITransactionService
    {
        public Task<int> CreateAsync(TransactionDto transactionDto, CancellationToken token = default);
        public Task<TransactionDto> GetByIdAsync(int id, CancellationToken token = default);
        public Task UpdateAsync(int id, TransactionDtoUpdate transactionDto, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
    }
}
