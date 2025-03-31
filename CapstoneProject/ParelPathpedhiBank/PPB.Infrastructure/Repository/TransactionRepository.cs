using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPB.Application.Interfaces;
using PPB.Application.Models;
using PPB.Domain.Models;
using PPB.Infrastructure.Context;

namespace PPB.Infrastructure.Repository
{
    internal class TransactionRepository : ITransactionRepository
    {
        readonly PPBDBContext _ppbDBContext;
        public TransactionRepository(PPBDBContext ppbDBContext)
        {
            _ppbDBContext = ppbDBContext;
        }
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _ppbDBContext.Transactions.ToListAsync();
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsByAccID(int accID)
        {
            return await _ppbDBContext.Transactions.Where(t => t.AccountID == accID).ToListAsync();
        }
        public async Task<TransactionDTO> AddTransactionAsync(TransactionDTO transaction)
        {
            var newTransaction = new Transaction()
            {
                AccountID = transaction.AccountID,
                TType = transaction.TType,
                Amount = transaction.Amount,
                Date = DateTime.Now,
                Description = transaction.Description
            };
            await _ppbDBContext.Transactions.AddAsync(newTransaction);
            await _ppbDBContext.SaveChangesAsync();
            return transaction;
        }
    }
}
