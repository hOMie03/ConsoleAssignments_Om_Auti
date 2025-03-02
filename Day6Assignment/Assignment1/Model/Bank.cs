using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Model
{
    internal class Bank
    {
        public string UserName { get; set; }
        Queue<string> tokenQueue = new Queue<string>();
        public Bank()
        {
            tokenQueue.Enqueue("Omie");
            tokenQueue.Enqueue("Sakthish");
        }
        public void AddToken(string user)
        {
            tokenQueue.Enqueue(user);
            Console.WriteLine($"Welcome {user}, you are in queue. Your wait number is {tokenQueue.Count}.");
        }
        public string CheckWhoIsNext()
        {
            return $"Next in line is: {tokenQueue.Peek()}";
        }
    }
}
