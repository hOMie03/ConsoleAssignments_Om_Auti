using Assignment1.Model;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Using class
            User user1 = new User("omie", "1234");
            Console.WriteLine($"Welcome, {user1.Username}.");
            Console.WriteLine($"There are currently {user1.GetLoggedInUsers()} logged in users!");
            User user2 = new User("sakth", "5678");
            Console.WriteLine($"Welcome, {user2.Username}.");
            Console.WriteLine($"There are currently {user2.GetLoggedInUsers()} logged in users!");
            User user3 = new User("kaps", "9012");
            Console.WriteLine($"Welcome, {user3.Username}.");
            Console.WriteLine($"There are currently {user3.GetLoggedInUsers()} logged in users!");
        }
    }
}
