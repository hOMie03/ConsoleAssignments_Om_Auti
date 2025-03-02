using Assignment2.Model;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Workshop w = new Workshop();
            Console.WriteLine("Welcome to the workshop!");

        takeName:
            Console.WriteLine("Please enter your name: ");
            string name = Convert.ToString(Console.ReadLine());
        takeID:
            Console.WriteLine("Please enter your student ID: ");
            int studID;
            bool checkID = int.TryParse(Console.ReadLine(), out studID);
            if(!checkID)
            {
                Console.WriteLine("Student IDs are numerical. Please enter the correct one:");
                goto takeID;
            }

            int choice = 0;
            do
            {
                Console.WriteLine("Please select any one workshop");
                Console.WriteLine("1. Art Workshop");
                Console.WriteLine("2. Tech-Exhibit Workshop");
                Console.WriteLine("3. Literature Workshop");
                Console.WriteLine("4. Register other student");
                Console.WriteLine("5. Exit");
            takeChoice:
                bool choiceCheck = int.TryParse(Console.ReadLine(), out choice);
                if(!choiceCheck)
                {
                    Console.WriteLine("Please enter correct choice: ");
                    goto takeChoice;
                }    
                switch (choice)
                {
                    case 1:
                        w.Add(studID, name, "Art");
                        break;
                    case 2:
                        w.Add(studID, name, "Tech");
                        break;
                    case 3:
                        w.Add(studID, name, "Literature");
                        break;
                    case 4:
                        Console.WriteLine("Registering other person");
                        goto takeName;
                    default:
                        Console.WriteLine("You have entered wrong input!");
                        break;
                }
                if (choice == 5)
                {
                    Console.WriteLine("Thank you for registering!");
                    break;
                }
            } while (choice <= 5);

        }
    }
}
