namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your HSC Percentage: ");
            double percentage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Student's Name: {name} \t Student's Age: {age} \t Student's HSC Percentage: {percentage}%");
            #endregion

            #region Q2
            bool isNumeric;
        takeAge:
            Console.WriteLine("Please enter your age again: ");
            isNumeric = int.TryParse(Console.ReadLine(), out age);
            if(isNumeric == true)
            {
                Console.WriteLine($"Your age is {age}.");
            }
            else
            {
                Console.WriteLine("Bad Input");
                Console.WriteLine("Please enter your age again: ");
                goto takeAge;
            }
            #endregion

            #region Q3
        takeMail:
            Console.WriteLine("Please enter your e-mail: ");
            string email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Please enter the e-mail.");
                goto takeMail;
            }
            else
            {
                Console.WriteLine($"Your e-mail is: {email}.");
            }

            #endregion
        }
    }
}
