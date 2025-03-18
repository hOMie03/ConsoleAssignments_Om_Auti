using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TicketTango.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, NotNull, MaxLength(50)]
        public string FirstName { get; set; }
        
        [AllowNull, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [NotMapped]
        public string Name {
            get { return Name; }
            set { Name = FirstName + " " + LastName; }
        }

        [Required, NotNull, EmailAddress]
        public string Email { get; set; }

        [Required, NotNull, RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{4,10}$")]
        public string Password { get; set; }

        [Required, NotNull]
        public Roles Roles { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }
    }
}
