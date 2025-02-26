using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Model
{
    internal class User
    {
        static int totalLoggedInUsers = 69;
        public string Username { get; set; }
        public string Password { get; set; }
        public User(string uname, string pswd)
        {
            Username = uname;
            Password = pswd;
            totalLoggedInUsers++;
        }
        public int GetLoggedInUsers()
        {
            return totalLoggedInUsers;
        }
    }
}
