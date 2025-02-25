namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            Console.WriteLine("Please enter the basic salary: ");
            double basicSalary = Convert.ToDouble(Console.ReadLine());
            double salaryAfterTaxDeduction = basicSalary * 0.10;
            double bonus;
            int ratings = 5;
            if(ratings >= 8)
            {
                bonus = basicSalary * 0.20;
            }
            else if(ratings >= 5)
            {
                bonus = basicSalary * 0.10;
            }
            else
            {
                bonus = 0;
            }
            double netSalary = basicSalary - salaryAfterTaxDeduction + bonus;
            Console.WriteLine($"Basic Salary: {basicSalary}");
            Console.WriteLine($"Tax Deduction 10%: -{salaryAfterTaxDeduction}");
            Console.WriteLine($"Bonus based on your ratings ({ratings}): +{bonus}");
            Console.WriteLine($"Your net salary after tax deduction and additional bonus based on ratings is: {netSalary}");
            #endregion

           
        }
    }
}
