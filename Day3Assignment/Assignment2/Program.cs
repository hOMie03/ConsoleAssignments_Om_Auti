namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q3
        takePswd:
            Console.WriteLine("Please create your password: ");
            string password = Console.ReadLine();
            if (password.Length < 6)
            {
                Console.WriteLine("Password must be at least 6 characters long.");
                goto takePswd;
            }
            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
                goto takePswd;
            }
            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("It must contain at least one digit.");
                goto takePswd;
            }
            Console.WriteLine("Your password has been created successfully.");
            #endregion
        }
    }
}
