﻿using Microsoft.AspNetCore.Identity;

namespace PPB.Models
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
