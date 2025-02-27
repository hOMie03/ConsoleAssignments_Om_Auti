using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Exception;
using Assignment1.Model;

namespace Assignment1.Repository
{
    internal class AccountRepository
    {
        List<UserAccount> accountsList;
        public AccountRepository()
        {
            accountsList = new List<UserAccount>
            {
                new UserAccount() {AccountNo = "13557", AccountName = "Sarthak"},
                new UserAccount() {AccountNo = "13558", AccountName = "Omie"},
                new UserAccount() {AccountNo = "13560", AccountName = "Sakthish"}
            };
        }
        public bool CheckUserAccount(UserAccount userAccount)
        {
            UserAccount accIDInput = GetAccountNo(userAccount.AccountNo);
            string num = userAccount.AccountNo;
            try
            {
                if(accIDInput != null)
                {
                    Console.WriteLine($"Welcome user {accIDInput.AccountName}");
                    return true;
                }
                if(!num.Any(char.IsDigit))
                {
                    throw new FormatException("Account Number should be numerical");
                }
                else
                {
                    throw new AccountNotFoundException($"{userAccount.AccountNo} not found.");
                }
            }
            catch (AccountNotFoundException anfex)
            {
                Console.WriteLine(anfex.Message);
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex.Message);
            }
            return false;
        }
        public UserAccount GetAccountNo(string accNo)
        {
            return accountsList.Find(p => p.AccountNo == accNo);
        }
    }
}
