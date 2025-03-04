using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyKirana.Interface
{
    internal interface IUser
    {
        public bool Login(string uname, string pswd);
    }
}
