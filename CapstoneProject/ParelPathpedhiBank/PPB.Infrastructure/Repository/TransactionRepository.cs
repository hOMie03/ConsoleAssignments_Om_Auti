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
            //var receiverAcc = await _ppbDBContext.Transactions.Where(t => t.Description.Substring(0, t.Description.IndexOf(' ') > 0 ? t.Description.IndexOf(' ') : t.Description.Length) == accID.ToString()).ToListAsync();
            return await _ppbDBContext.Transactions.Where(t => t.AccountID == accID).ToListAsync();
        }
        public async Task<TransactionDTO> AddTransactionAsync(TransactionDTO transaction)
        {
            var findAccID = await _ppbDBContext.Accounts.FirstOrDefaultAsync(a => a.Id == transaction.AccountID);
            var firstDescWord = transaction.Description.Split(' ').FirstOrDefault();
            var receiverAccount = await _ppbDBContext.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == Convert.ToInt32(firstDescWord));
            if(findAccID != null)
            {
                var sendersTransaction = new Transaction()
                {
                    AccountID = transaction.AccountID,
                    TType = TransactionTypes.Debit,
                    Amount = transaction.Amount,
                    Date = DateTime.Now,
                    Description = transaction.Description
                };
                if (receiverAccount != null)
                {
                    receiverAccount.Balance = receiverAccount.Balance + transaction.Amount;
                    var receiversTransaction = new Transaction()
                    {
                        AccountID = receiverAccount.Id,
                        TType = TransactionTypes.Debit,
                        Amount = transaction.Amount,
                        Date = DateTime.Now,
                        Description = $"You received {transaction.Amount} from Account ID {transaction.AccountID} with message {transaction.Description.Substring((transaction.Description.IndexOf("with the message '") + "with the message '".Length), (transaction.Description.LastIndexOf("'")) - (transaction.Description.IndexOf("with the message '") + "with the message '".Length))}"
                    };
                    await _ppbDBContext.Transactions.AddAsync(receiversTransaction);
                }
                if(transaction.TType == TransactionTypes.Debit)
                {
                    if (findAccID.Balance > transaction.Amount)
                        findAccID.Balance = findAccID.Balance - transaction.Amount;
                    else
                        throw new InsufficientBalanceException($"You don't have enough balance to send money");
                }
                await _ppbDBContext.Transactions.AddAsync(sendersTransaction);
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
