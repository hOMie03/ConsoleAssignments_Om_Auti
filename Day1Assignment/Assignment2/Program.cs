namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q4
            bool isDate;
        takeDate:
            DateTime dischargeDate;
            Console.WriteLine("Please enter discharge date of patient (MM-DD-YYYY): ");
            isDate = DateTime.TryParse(Console.ReadLine(), out dischargeDate);
            if(isDate == true)
            {
                Console.WriteLine($"Discharge Date is: {dischargeDate.ToString("dd/MM/yyyy")}");
            }
            else
            {
                Console.WriteLine("Not Discharged.");
                goto takeDate;
            }
            #endregion
        }
    }
}
