using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TicketTango.ViewModels
{
    public class LoginUserModel
    {
        [Required, NotNull, EmailAddress]
        public string Email { get; set; }
        
        [Required, NotNull]
        public string Password { get; set; }
    }
}
