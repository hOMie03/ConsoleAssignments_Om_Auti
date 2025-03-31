using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPB.Application.Interfaces;
using PPB.Application.Models;
using PPB.Domain.Models;
using PPB.Infrastructure.Context;

namespace PPB.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        readonly PPBDBContext _ppbDBContext;
        public AccountRepository(PPBDBContext ppbDBContext)
        {
            _ppbDBContext = ppbDBContext;
        }
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _ppbDBContext.Accounts.ToListAsync();
        }
        public async Task<IEnumerable<Account>> GetAccountsByUserID(string userID)
        {
            return await _ppbDBContext.Accounts.Where(a => a.UserID == userID).ToListAsync();
        }
        public async Task<AddAccountDTO> AddAccountAsync(AddAccountDTO newAccount)
        {
            Random random = new Random();
            var newAcc = new Account()
            {
                UserID = newAccount.UserID,
                AccountNumber = random.Next(1000000, 10000000),
                AccountType = newAccount.AccountType,
                Balance = newAccount.Balance,
                CreatedDate = DateTime.Now                
            };
            await _ppbDBContext.Accounts.AddAsync(newAcc);
            await _ppbDBContext.SaveChangesAsync();
            return newAccount;
        }
        public async Task<bool> DeleteAccountAsync(string userID, int accID)
        {
            var foundAcc = await _ppbDBContext.Accounts.FirstOrDefaultAsync(a => a.UserID == userID && a.Id == accID);
            if (foundAcc is not null)
            {
                _ppbDBContext.Accounts.Remove(foundAcc);
                return await _ppbDBContext.SaveChangesAsync() > 0;

            }
            return false;
        }

        public async Task<UpdateAccountDTO> UpdateAccountAsync(int id, UpdateAccountDTO account)
        {
            var existingAccount = await _ppbDBContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (existingAccount is not null)
            {
                existingAccount.AccountType = account.AccountType;
                _ppbDBContext.Accounts.Update(existingAccount);
                await _ppbDBContext.SaveChangesAsync();
                return account;
            }
            return null;
        }
    }
}
