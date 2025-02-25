namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q2
            int choice = 0;
            string trainType ="";
            int typeAmt = 0, noOfTickets;
            double totalTicketAmt;
            do
            {
                takeChoice:
                Console.WriteLine("--- Online Train Booking System ---");
                Console.WriteLine("Select the type of train ticket you want to book:");
                Console.WriteLine("1. General (Rs. 200)\n2. AC (Rs. 1000)\n3. Sleeper (Rs. 500)\n4. Exit");
                bool isChoice = int.TryParse(Console.ReadLine(), out choice);
                if(isChoice == false)
                {
                    Console.WriteLine("Please enter correct choice number.");
                    goto takeChoice;
                }
                switch (choice)
                {
                    case 1:
                        trainType = "General";
                        typeAmt = 200;
                        break;
                    case 2:
                        trainType = "AC";
                        typeAmt = 1000;
                        break;
                    case 3:
                        trainType = "Sleeper";
                        typeAmt = 500;
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice number.");
                        break;
                }

                if (choice >= 1 && choice < 4)
                {
                    Console.WriteLine("How many tickets do you want to buy: ");
                    noOfTickets = Convert.ToInt32(Console.ReadLine());
                    totalTicketAmt = typeAmt * noOfTickets;
                    Console.WriteLine($"Your Total Amount to be paid for {noOfTickets} {trainType} ticket(s) is: Rs. {totalTicketAmt}");
                    Console.WriteLine("Thank you for booking.:)");
                }
            } while (choice != 4);
            #endregion
        }
    }
}
