using Assignment1.Model;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            Car c1 = new Car();
            c1.SetCarDetails(1, "Toyota", "Corolla", 2024, 100000);
            c1.GetCarDetails();
            #endregion

            #region Q2
            Car c2 = new Car(); // Default Constructor
            c2.GetCarDetails();
            Car c3 = new Car(2, "Honda", "City", 2022, 500000); // Overloaded Parameterized Constructor
            c3.GetCarDetails();
            #endregion
        }
    }
}
