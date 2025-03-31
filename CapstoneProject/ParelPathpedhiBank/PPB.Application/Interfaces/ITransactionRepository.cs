using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Application.Models;
using PPB.Domain.Models;

namespace PPB.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<IEnumerable<Transaction>> GetTransactionsByAccID(int accID);

        Task<TransactionDTO> AddTransactionAsync(TransactionDTO transaction);
    }
}
