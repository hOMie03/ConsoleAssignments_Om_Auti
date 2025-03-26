using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Domain.Interfaces;
using PPB.Domain.Models;

namespace PPB.Application.Services
{
    public class AccountService : IAccountService
    {
        readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<List<Account>> GetAllAccounts()
        {
            return await _accountRepository.GetAllAccounts();
        }
    }
}
