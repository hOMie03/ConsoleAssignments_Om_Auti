using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    internal class Manager : Employee
    {
        public decimal Bonus { get; set; }

        public Manager(string name, decimal salary, decimal bon):base(name, salary)
        {
            Bonus = bon;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine("---Employee Details---");
            Console.WriteLine($"Name: {EmpName} \t Salary: {EmpSalary} \t Bonus: {Bonus}");
        }
    }
}
