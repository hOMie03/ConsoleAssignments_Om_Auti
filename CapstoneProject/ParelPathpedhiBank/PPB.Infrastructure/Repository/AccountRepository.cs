using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPB.Application.Interfaces;
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
    }
}
