﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPB.Application.Exceptions
{
    public class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException(string message) : base(message) { }
    }
}
