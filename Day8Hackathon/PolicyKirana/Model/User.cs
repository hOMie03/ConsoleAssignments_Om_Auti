using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyKirana.Interface;

namespace PolicyKirana.Model
{
    internal class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        Dictionary<string, string> userData = new Dictionary<string, string>();

        // Constructor Initialization
        public User()
        {
            userData["admin"] = "admin";
        }

        // Register User
        public void Register(string uname, string pswd)
        {
            Username = uname;
            Password = pswd;
            userData[Username] = Password;
            Console.WriteLine("Registered Successfully");
            //Console.WriteLine(userData.Count);
            //foreach (var item in userData)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}
        }

        // Login User
        public bool Login(string uname, string pswd)
        {
            Username = uname;
            Password = pswd;
            try
            {
                if (userData[Username] == Password)
                {
                    Console.WriteLine("Correct Hai!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Nuh-uh!");
                    return false;
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("Wrong credentials");
            }
            return false;
        }

    }
}
