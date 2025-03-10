using PolicyKirana.Model;

namespace PolicyKirana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            string uname, pswd;
            Policy policy = new Policy();
            Console.WriteLine("PolicyKirana - All your policies at one place");
            Console.WriteLine("---------------------------------------------");
            do
            {
            takeFirstChoice:
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Signup");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Please select any one option: ");
                bool choiceCheck = int.TryParse(Console.ReadLine(), out choice);
                if (!choiceCheck)
                {
                    Console.WriteLine("Incorrect Input!");
                    goto takeFirstChoice;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter your username: ");
                        uname = Console.ReadLine();
                        Console.WriteLine("Please enter the password: ");
                        pswd = Console.ReadLine();
                        bool loginSuccess = policy.Login(uname, pswd);
                        if (loginSuccess)
                        {
                            Console.WriteLine("Login Successful!");
                            policy.Options();
                        }
                        else
                        {
                            Console.WriteLine("Wrong username or password.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Please enter your username: ");
                        uname = Console.ReadLine();
                        Console.WriteLine("Please create a new password: ");
                        pswd = Console.ReadLine();
                        int checkReg = policy.Register(uname, pswd);
                        if(checkReg > 0)
                        {
                            Console.WriteLine("Registered Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Registration Unsuccessful!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using PolicyKirana!");
                        break;
                    default:
                        Console.WriteLine("Incorrect Input, please enter again");
                        break;
                }
                if (choice == 3) break;
            } while (choice < 4);

        }
    }
}
