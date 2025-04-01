using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPB.Application.Exceptions;
using PPB.Application.Interfaces;
using PPB.Application.Models;
using PPB.Domain.Models;
using PPB.Domain.Models.Constants;
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
            var findAccID = await _ppbDBContext.Accounts.FirstOrDefaultAsync(a => a.Id == transaction.AccountID);
            if(findAccID != null)
            {
                var newTransaction = new Transaction()
                {
                    AccountID = transaction.AccountID,
                    TType = transaction.TType,
                    Amount = transaction.Amount,
                    Date = DateTime.Now,
                    Description = transaction.Description
                };
                if(transaction.TType == TransactionTypes.Credit)
                {
                    findAccID.Balance = findAccID.Balance + transaction.Amount;
                }
                if(transaction.TType == TransactionTypes.Debit)
                {
                    if (findAccID.Balance > transaction.Amount)
                        findAccID.Balance = findAccID.Balance - transaction.Amount;
                    else
                        throw new InsufficientBalanceException($"You don't have enough balance to send money");
                }
                await _ppbDBContext.Transactions.AddAsync(newTransaction);
                await _ppbDBContext.SaveChangesAsync();
                return transaction;
            }
            else
            {
                throw new AccountNotFoundException($"Account with ID {transaction.AccountID} not found.");
            }
        }
    }
}
