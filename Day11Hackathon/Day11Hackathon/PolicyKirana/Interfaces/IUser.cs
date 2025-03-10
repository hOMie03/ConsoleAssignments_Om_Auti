using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyKirana.Interfaces
{
    internal interface IUser
    {
        public bool Login(string uname, string pswd);
        public int Register(string uname, string pswd);
    }
}
