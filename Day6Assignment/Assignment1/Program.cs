using Assignment1.Model;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name: ");
            string name = Convert.ToString(Console.ReadLine());
            Bank bank = new Bank();
            bank.AddToken(name);
            Console.WriteLine(bank.CheckWhoIsNext());

            Console.WriteLine("Please enter your name: ");
            string name2 = Convert.ToString(Console.ReadLine());
            bank.AddToken(name2);
            Console.WriteLine(bank.CheckWhoIsNext());
        }
    }
}
