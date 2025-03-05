using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyKirana.Exception;
using PolicyKirana.Model;

namespace PolicyKirana.Repository
{
    internal class YourPolicyData
    {
        List<Policy> policyData = new List<Policy>();
        public YourPolicyData() { }

        // Adding policy
        public void AddYourPolicies(PType policyType, int pTypeNum, string uname)
        {
            string pID = pTypeNum + uname + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
            TimeSpan addDate = new TimeSpan(365, 0, 0, 0);
            DateTime endD = DateTime.Now.Add(addDate);
            int flag = 0;

            foreach (var policy in policyData)
            {
                if (uname == policy.PolicyHolderName && policyType == policy.PolicyType)
                {
                    flag = 1;
                    Console.WriteLine($"You already have {policyType} Policy.");
                    break;
                }
                flag = 0;
            }
            if (flag == 0)
            {
                policyData.Add(
                    new Policy() { PolicyID = pID, Username = uname, PolicyHolderName = uname, PolicyType = policyType, StartDate = DateTime.Now, EndDate = endD }
                );
                Console.WriteLine($"{policyType.ToString()} Policy added successfully.");
                ViewYourPolicy(uname);
            }
        }

        // Searching Policy by ID
        public void SearchYourPolicy(string pID, string uname)
        {
            foreach (var policy in policyData)
            {

                if (pID == policy.PolicyID && uname == policy.Username)
                {
                    Console.WriteLine($"Policy Holder Name: {policy.PolicyHolderName} \t ID: {policy.PolicyID} \t Type: {policy.PolicyType}");
                    Console.WriteLine($"Start Date: {policy.StartDate} \t End Date: {policy.EndDate}");
                    break;
                }
                else
                {
                    Console.WriteLine("No policy found!");
                }
            }
        }

        // Updating Policy by ID
        public void UpdateYourPolicy(string pID, string uname)
        {
            foreach (var policy in policyData)
            {
                if (pID == policy.PolicyID && uname == policy.Username)
                {
                    Console.WriteLine("Do you want to change the policy holder name (Press y if yes): ");
                    string changeName = Console.ReadLine();
                    string name;
                    if (changeName.ToUpper() == "Y")
                    {
                        Console.WriteLine("Enter policy holder name: ");
                        name = Console.ReadLine();
                        policy.PolicyHolderName = name;
                    }
                    Console.WriteLine("Change the start date (MM-DD-YYYY): ");
                    DateTime startDate= Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("How many years do you want the policy to be alive: ");
                    var yearOfPolicies = Convert.ToInt32(Console.ReadLine());
                    int diff = startDate.Year + yearOfPolicies;
                    DateTime endDate = new DateTime(diff, startDate.Month, startDate.Day);
                    policy.StartDate = startDate;
                    policy.EndDate = endDate;
                    Console.WriteLine("Do you want to change the policy type (Press y if yes): ");
                    string changeType = Console.ReadLine();
                    string type;
                    if (changeType.ToUpper() == "Y")
                    {
                        takePolicyChoice:
                        Console.WriteLine("Which Type? Enter choice number\n(1. Life, 2. Health, 3. Vehicle, 4. Property): ");
                        int pType = Convert.ToInt32(Console.ReadLine());
                        if (pType > 0 && pType < 4)
                        {
                            PType chosenType = (PType)pType;
                            policy.PolicyType = chosenType;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input added!");
                            goto takePolicyChoice;
                        }
                    }
                    Console.WriteLine("Updated Successfully!");
                    break;
                }
                else
                {
                    Console.WriteLine("Policy not found!");
                }
            }
        }

        // Deleting Policy by ID
        public void DeleteYourPolicy(string pID, string uname)
        {
            // Exception Handling
            try
            {
                foreach (var policy in policyData)
                {

                    if (pID == policy.PolicyID && uname == policy.Username)
                    {
                        policyData.Remove(policy);
                        Console.WriteLine($"Your Policy having ID {pID} has successfully been deleted.");
                        break;
                    }
                    else
                    {
                        throw new PolicyNotFound("Policy not found. Please enter correct policy ID");
                    }
                }
            }
            catch (PolicyNotFound pnfex)
            {
                Console.WriteLine(pnfex.Message);
            }
        }

        // Viewing Policy
        public void ViewYourPolicy(string uname)
        {
            foreach (var policy in policyData)
            {
                if (uname == policy.Username)
                {
                    if (policyData.Count == 0)
                    {
                        Console.WriteLine("No policies");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Policy Holder Name: {policy.PolicyHolderName} \t ID: {policy.PolicyID} \t Type: {policy.PolicyType}");
                        Console.WriteLine($"Start Date: {policy.StartDate} \t End Date: {policy.EndDate}");
                    }
                }
            }
        }

        // Checking active policies
        public bool IsActive(string uname)
        {
            foreach (var policy in policyData)
            {
                if (uname == policy.Username)
                {
                    if (policy.EndDate < DateTime.Now)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
