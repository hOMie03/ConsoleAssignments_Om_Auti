using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Domain.Models;

namespace PPB.Application.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccounts();
    }
}
