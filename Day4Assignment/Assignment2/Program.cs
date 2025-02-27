using Assignment2.Model;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q2
            // Child Class Instance
            Manager manager = new Manager("Sakthish", 60000, 9000); 
            manager.DisplayDetails();

            // Base Class Instance
            Employee employee = new Employee("Omie", 30000);
            employee.DisplayDetails();
            
            // Base Class Instance with Child Class Object; override function called
            Employee empMan = new Manager("Atharva", 40000, 2000);
            empMan.DisplayDetails();
            #endregion
        }
    }
}
