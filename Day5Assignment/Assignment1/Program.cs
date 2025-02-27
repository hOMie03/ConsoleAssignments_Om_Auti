using Assignment1.Model;
using Assignment1.Repository;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your Account Number: ");
            string accNo = Console.ReadLine();
            UserAccount account = new UserAccount() { AccountNo = accNo };
            AccountRepository accountRepo = new AccountRepository();
            bool checkAccNo = accountRepo.CheckUserAccount(account);
            if(checkAccNo)
            {
                Console.WriteLine("User found.");
            }  


        }
    }
}
