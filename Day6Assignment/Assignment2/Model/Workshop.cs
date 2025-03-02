using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    internal class Workshop
    {
        HashSet<Tuple<int, string, string>> workshopPeeps = new HashSet<Tuple<int, string, string>>();
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string WorkshopType { get; set; }
        public void Add(int id, string name, string type)
        {
            StudentID = id;
            StudentName = name;
            WorkshopType = type;
            foreach(var item in workshopPeeps)
            {
                if(item.Item1.Equals(StudentID) && item.Item3.Equals(WorkshopType))
                {
                    Console.WriteLine($"You have already registered for the {item.Item2} workshop!");
                    return;
                }
            }
            workshopPeeps.Add(new Tuple<int, string, string>(StudentID, StudentName, WorkshopType));
            Console.WriteLine($"Thank you for registering, {StudentName} ({StudentID})! You are now part of the following workshop(s): ");
            foreach (var item in workshopPeeps)
            {
                if (item.Item1.Equals(StudentID))
                {
                    Console.WriteLine(item.Item3);
                }
            }
            Console.WriteLine("You can even register for other remaining workshops!");
            //Console.WriteLine(workshopPeeps.Count);
        }
}
}
