using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPB.Domain.Interfaces;
using PPB.Domain.Models;
using PPB.Infrastructure.Context;

namespace PPB.Infrastructure.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        readonly PPBDBContext _ppbDbContext;
        public AccountRepository(PPBDBContext ppbDbContext)
        {
            _ppbDbContext = ppbDbContext;
        }
        public async Task<List<Account>> GetAllAccounts()
        {
            return await _ppbDbContext.Accounts.ToListAsync();
        }
    }
}
