using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPB.Application.Models.Identity
{
    public class RegistrationRequest // Register
    {
        [Required, NotNull]
        public string Name { get; set; }

        [Required, NotNull, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{4,10}$")]
        public string Password { get; set; } = string.Empty;
    }
}
