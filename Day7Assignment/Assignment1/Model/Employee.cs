using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Model
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeExpYear { get; set; }

        public Employee(int id, string name, DateTime year)
        {
            EmployeeID = id;
            EmployeeName = name;
            EmployeeExpYear = year;
        }
    }
}
