using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Domain.Models;

namespace PPB.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccounts();
    }
}
