using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Model
{
    static class EmployeeExtension
    {
        public static void CalculateExperience(this Employee employee)
        {
            int nowYear = DateTime.Now.Year;
            int expYear = Convert.ToInt32(employee.EmployeeExpYear.Year);
            int totalExpYears = nowYear - expYear;
            Console.WriteLine($"{employee.EmployeeName}, your total years of experience is: {totalExpYears} years.");

        }
    }
}
