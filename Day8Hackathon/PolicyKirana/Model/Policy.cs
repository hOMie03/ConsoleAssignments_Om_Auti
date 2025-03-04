using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PolicyKirana.Interface;
using PolicyKirana.Repository;

namespace PolicyKirana.Model
{
    internal class Policy : User, IPolicy
    {
        public string PolicyID { get; set; }
        public string PolicyHolderName { get; set; }
        public PType PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        YourPolicyData pD = new YourPolicyData();

        // First Options after login
        public void Options()
        {
            int choice = 0;
            Console.WriteLine($"Welcome, {Username}!");
            do
            {
            takeSecondChoice:
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Your policies");
                Console.WriteLine("2. Register/Add new policy");
                Console.WriteLine("3. Sign out");
                bool choiceCheck = int.TryParse(Console.ReadLine(), out choice);
                if (!choiceCheck)
                {
                    Console.WriteLine("Incorrect Input!");
                    goto takeSecondChoice;
                }
                switch (choice)
                {
                    case 1:
                        PolicyMenu();
                        break;
                    case 2:
                        RegisterNewPolicies();
                        break;
                    case 3:
                        Console.WriteLine("Signing Out!");
                        break;
                    default:
                        Console.WriteLine("Incorrect Input!");
                        break;
                }
                if (choice == 3) break;
            } while (choice < 4);
        }

        // Clicking on your policies
        public void PolicyMenu()
        {
            int choice = 0;
            do
            {
            takeOwnChoice:
                Console.WriteLine("Choose the policy you are interested in: ");
                Console.WriteLine("1. Search Policy by Policy ID");
                Console.WriteLine("2. Update Policy Details");
                Console.WriteLine("3. Delete a Policy");
                Console.WriteLine("4. View Active Policy");
                Console.WriteLine("5. Go back");
                bool choiceCheck = int.TryParse(Console.ReadLine(), out choice);
                if (!choiceCheck)
                {
                    Console.WriteLine("Incorrect Input!");
                    goto takeOwnChoice;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter the Policy ID: ");
                        string pidSearch = Console.ReadLine();
                        pD.SearchYourPolicy(pidSearch);
                        break;
                    case 2:
                        Console.WriteLine("Please enter the Policy ID to update: ");
                        string pidUpdate = Console.ReadLine();
                        pD.UpdateYourPolicy(pidUpdate);
                        break;
                    case 3:
                        Console.WriteLine("Please enter the Policy ID to search: ");
                        string pidDelete = Console.ReadLine();
                        pD.DeleteYourPolicy(pidDelete);
                        break;
                    case 4:
                        pD.ViewYourPolicy(Username);
                        break;
                    case 5:
                        Console.WriteLine("Going back...");
                        break;
                    default:
                        Console.WriteLine("Incorrect Input!");
                        break;
                }
                if (choice == 5) break;
            } while (choice < 6);

        }

        // Showing Available Policies
        public void ShowAvailablePolicies()
        {
            int num = 1;
            foreach (var item in Enum.GetValues(PolicyType.GetType()))
            {
                Console.WriteLine($"{num}. {item}");
                num++;
            }
        }

        // Registering New Policies
        public void RegisterNewPolicies()
        {
            int choice = 0;
        takePolicyChoice:
            Console.WriteLine("Choose the policy you are interested in: ");
            ShowAvailablePolicies();
            Console.WriteLine("5. Exit");
            bool choiceCheck = int.TryParse(Console.ReadLine(), out choice);
            if (!choiceCheck)
            {
                Console.WriteLine("Incorrect Input!");
                goto takePolicyChoice;
            }
            if (choice == 5)
            {
                Console.WriteLine("Going Back!");
            }
            else
            {
                PType chosenType = (PType)choice;
                int typeNum = (int)chosenType;
                pD.AddYourPolicies(chosenType, typeNum, Username);
            }
        }
    }
}
