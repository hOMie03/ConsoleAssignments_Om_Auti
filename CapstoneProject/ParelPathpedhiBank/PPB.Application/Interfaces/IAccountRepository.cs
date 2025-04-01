using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PPB.Application.Models;
using PPB.Domain.Models;

namespace PPB.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<IEnumerable<Account>> GetAccountsByUserID(string userID);

        Task<AddAccountDTO> AddAccountAsync(AddAccountDTO newAccount);
        Task<bool> DeleteAccountAsync(string userID, int accNo);
        Task<UpdateAccountDTO> UpdateAccountAsync(int id, UpdateAccountDTO account);
    }
}
