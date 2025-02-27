using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Exception
{
    internal class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException() { }
        public AccountNotFoundException(string message) : base(message) { }
    }
}
