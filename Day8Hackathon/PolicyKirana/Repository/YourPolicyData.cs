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
        public void SearchYourPolicy(string pID)
        {
            foreach (var policy in policyData)
            {

                if (pID == policy.PolicyID)
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
        public void UpdateYourPolicy(string pID)
        {
            foreach (var policy in policyData)
            {
                if (pID == policy.PolicyID)
                {
                    Console.WriteLine("Do you want to change the policy holder name (y/n): ");
                    string changeName = Console.ReadLine();
                    string name;
                    if (changeName.ToUpper() == "Y")
                    {
                        Console.WriteLine("Enter policy holder name: ");
                        name = Console.ReadLine();
                        policy.PolicyHolderName = name;
                    }
                    Console.WriteLine("Change the start date: ");
                    DateTime startDate= Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("How many years do you want the policy to be alive: ");
                    var yearOfPolicies = Convert.ToInt32(Console.ReadLine());
                    int diff = startDate.Year + yearOfPolicies;
                    DateTime endDate = new DateTime(diff,startDate.Month,startDate.Day); 
                    Console.WriteLine("Which Type (1. Life, 2. Health, 3. Vehicle, 4. Property): ");
                    int pType = Convert.ToInt32(Console.ReadLine());
                    PType chosenType = (PType)pType;
                    policy.StartDate = startDate;
                    policy.EndDate = endDate;
                    policy.PolicyType = chosenType;
                    Console.WriteLine("Updated Successfully!");
                    break;
                }
                else
                {
                    Console.WriteLine("Policy not found!");
                }
            }
        }
        public void DeleteYourPolicy(string pID)
        {
            try
            {
                foreach (var policy in policyData)
                {

                    if (pID == policy.PolicyID)
                    {
                        policyData.Remove(policy);
                        Console.WriteLine($"Your Policy having ID {pID} has successfully been deleted.");
                        break;
                    }
                    else
                    {
                        throw new PolicyNotFound("Policy not found");
                    }
                }
            }
            catch (PolicyNotFound pnfex)
            {
                Console.WriteLine(pnfex.Message);
            }
        }
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



    }
}
