﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PPB.Domain.Models
{
    public class User : IdentityUser
    {
        //public string Id { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string Role { get; set; }
    }
}
