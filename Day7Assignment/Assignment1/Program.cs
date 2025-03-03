using Assignment1.Model;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            Console.WriteLine("Employee Portal");
            Console.WriteLine("Please enter your employee ID: ");
            int empID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your name: ");
            string empName = Console.ReadLine();
            Console.WriteLine("Please enter the date of joining (MM-DD-YYYY): ");
            DateTime year = Convert.ToDateTime(Console.ReadLine());
            Employee e = new Employee(empID, empName, year);
            e.CalculateExperience();
            #endregion
        }
    }
}
