using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    internal class Employee
    {
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }

        public Employee(string name, decimal salary)
        {
            EmpName = name;
            EmpSalary = salary;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("---Employee Details---");
            Console.WriteLine($"Name: {EmpName} \t Salary: {EmpSalary}");
        }
    }
}
